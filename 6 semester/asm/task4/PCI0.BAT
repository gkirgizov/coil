; @goto build
    model tiny
    .code
    .386
    org 100h
_:  jmp start

num_vendors dw 613
vendors db 'vendors', 0
devices db 'devices', 0
names db 'names', 0
handle dw 0

bs_result db 10 dup(0)
bs_target db 8 dup(0)
pci_info:
_bus db 'bus:____ '
_dev db 'dev:____ '
_cls db 'cls:__ '
_sub db 'sub:__ '
_fun db 'fun:__ '
_vid db 'vid:____ '
_did db 'did:____'
_ln db 13, 10
_txt db 160 dup(0)
_end db 13, 10, '$'

_buf db '    ', 13, 10, '$'
msg_error db 'error code ', '$'
msg_test  db 'Like city lights, receding into darkness...', 13, 10, '$'
msg_op_er db 'open error', 13, 10, '$'
msg_rd_er db 'read error', 13, 10, '$'
msg_cl_er db 'close error', 13, 10, '$'
msg_pt_er db 'pointer error', 13, 10, '$'

start:
    pushad
    mov dx, 0CF8h ; CONFIG_ADDRESS
    mov ecx, 80000000h ; set bus:0 device:0 function:0
pci_iter:
;    mov eax, ecx ; store address
;    add eax, 0Ch ; offset of register: get field 'Header Type' to determine is device multifunctional (bit 7)
;    out dx, eax  ; send query; get 0Ch register
;    add dx, 4  ; CONFIG_DATA (0CFCh) register
;    in eax, dx  ; read
    xor ebp, ebp ; reset for function counter
;    sub dx, 4  ; get zero offset again (did and vid register)
;    shr eax, 23  ; move bit 7 ('multifunctional' flag)
;    and ax, 1 ; get only bit 7
fun_mult:
    mov eax, ecx ; device address with zero offset
    shl ebp, 8 ; move fun number bits to match CONFIG_ADDRESS structure (8-10 bits)
    add eax, ebp ; get this function
    shr ebp, 8

    push eax
    add eax, 8 ; get another register
    out dx, eax
    add dx, 4 ; 0CFCh
    in eax, dx ; [[class code; subclass][prog if; revision id]]
    mov ebx, eax
    sub dx, 4 ; 0CF8h
    pop eax

    out dx, eax
    add dx, 4  ; 0CFCh
    in eax, dx  ; eax = [[device id][vendor id]]
    sub dx, 4  ; 0CF8h

    call print_info
    inc bp  ; next function
    cmp bp, 8 ; max 8 functions
    jl fun_mult
next_iter:
    add ecx, 0800h ; next device
    test ecx, 01000000h ; if there're more devices (24 bit)
    jz pci_iter  ; then go to the next iteration
    popad
    ret

print_info:
    ; input:
    ; eax - vendor id, device id
    ; ecx - bus number, device number
    ; ebx - class code, subclass, prog if, revision id
    ; ebp - function number
    cmp ax, -1 ; check if device actually exists
    je print_info_end

    push eax
    push edx
    push edi
    push ds
    pop es

    call print_bus
    call print_dev
call print_cls
    call print_fun
    call print_ids
    call print_names

    mov ax, 0900h
    lea dx, pci_info
    int 21h
    call clear_text ; clean 'text' buffer from now useless string

    pop edi
    pop edx
    pop eax
print_info_end:
    ret

print_bus: ; print bus number from ecx
    push eax
    mov eax, ecx
    shr eax, 10h ; get bus number in bits 23-16
    and ax, 00FFh ; left only bits 23-16
    cld
    lea di, _bus[4]
    call h4
    pop eax
    ret
print_dev: ; print device number from ecx
    push eax
    mov eax, ecx
    shr eax, 11  ; get device number in bits 15-11
    and al, 00011111b ; left only bits 15-11
    cld
    lea di, _dev[4]
    call h4
    pop eax
    ret
print_cls:
    push eax
    mov eax, ebx
    cld
    shr eax, 10h ; class code and subclass
    xchg ah, al ; class code in al now
    lea di, _cls[4]
    call h2
    xchg ah, al ; subclass in al now
    lea di, _sub[4]
    call h2
    pop eax
    ret
print_fun: ; print function number from ebp
    push eax
    mov eax, ebp
    cld
    lea di, _fun[4]
    call h2
    pop eax
    ret
print_ids: ; print vendor id and device id from eax
    push eax
    cld
    lea di, _vid[4]
    call h4 ; vendor id in ax
    shr eax, 10h ; move device id to ax
    lea di, _did[4]
    call h4 ; device id in ax
    pop eax
    ret

print_names: ; print vendor name and product name from vendor_id and product_id in eax
    pushad
    push eax

; Part 1: searching for vendor_id line that contains
;   information about line numbers of devices of that vendor in devices.txt
    lea dx, vendors
    call open_file

    xor bx, bx ; initial left border
    mov cx, num_vendors ; initial right border
    mov dx, 6 ; record size (3 words)
    mov word ptr [bs_target], ax ; value we search for
    call bsearch ; now we have record with the data we need in bs_result
    call close_file ; close vendors file

; Part 2: searching for device_id line that contains
;   information about symbol offsets of the text in names.txt
    lea dx, devices
    call open_file

    ; set parameters for binary search
    mov bx, word ptr[bs_result+2] ; left border
    mov cx, word ptr[bs_result+4] ; right border
    mov dx, 10 ; record size (1 word + 2 dwords)
    ; get true device_id from eax
    pop eax
    shr eax, 10h
    mov word ptr [bs_target], ax ; value we search for
    call bsearch ; now we have record with the data we need in bs_result
    call close_file ; close devices file

; Part 3: open file with names and by byte offsets read the name
    lea dx, names
    call open_file

    ; save offsets
    mov ebx, dword ptr[bs_result+2] ; start offset
    mov ecx, dword ptr[bs_result+6] ; end offset
    push ebx
    push ecx

    ; lseek to the start offset (offset in ebx)
    ; first, unpack 32bit register to 2x16bit regiters
    mov dx, bx ; lower part
    shr ebx, 10h
    mov cx, bx ; upper part
    xor al, al ; counting from the beginning of file
    mov ah, 42h
    mov bx, handle
    int 21h
    jc pointer_error

    ; read data
    pop ecx
    pop ebx
    sub ecx, ebx ; cx now contains number of bytes to read
    mov ah, 3Fh ; Read File function
    mov bx, handle
    lea dx, _txt ; buffer for name
    int 21h
    jc read_error

    call close_file ; close names file
    popad
    ret

; TODO: case for NOT FOUND
bsearch:
    ; bs_target - value we search for
    ; handle - file to search in
    ; bx - left border
    ; cx - right border
    ; dx - record size in bytes
    pushad ; push all double
bs_loop:
    ; save input data
    push ecx
    push ebx

    ; calc middle point (in ecx)
    cmp cx, bx
    je bs_exit_cond
    add cx, bx
    shr cx, 1
    push ecx

    ; setting pointer in the file to the middle point
    push dx ; save record size
    mov ax, dx ; set record size
    mul cx ; shift of the record is in dx:ax
    mov cx, dx ; that 32bit int is in dx:ax, but we need it in cx:dx
    mov dx, ax ;
    mov al, 0 ; counting from the beginning of file
    mov ah, 42h ; LSEEK function (set pointer in the file)
    mov bx, handle
    int 21h
    jc pointer_error

    ; reading record at the pointer
    mov ah, 3Fh
    mov bx, handle
    pop cx ; set record size
    push cx
    lea dx, bs_result ; buffer to read to
    int 21h
    jc read_error
    pop dx ; restore record size for next iteration

    mov ax, word ptr[bs_result]
    ; compare target value and current value at the middle point
    cmp ax, word ptr[bs_target]
    jb bs_more
    ja bs_less
    pop ecx
    jmp bs_exit_cond
bs_less: ; take step to the left border
    pop ecx ; middle point is the right border now
    pop ebx ; pop the old left border - it is the same
    pop eax ; just clear the stack from the old right border
    jmp bs_loop
bs_more: ; take step to the right border
    pop ebx ; middle point is the left border now
    pop ecx ; pop the old left border
    pop ecx ;   to get the old right border - it is the same
    jmp bs_loop
bs_exit_cond:
    pop ebx
    pop ecx
    popad ; pop all double
    ret

open_error:
    lea dx, msg_op_er
    jmp error_handle
read_error:
    lea dx, msg_rd_er
    jmp error_handle
close_error:
    lea dx, msg_cl_er
    jmp error_handle
pointer_error:
    lea dx, msg_pt_er
error_handle:
    mov cx, ax ; error code in ax
    mov ax, 0900h
    int 21h
    mov ax, 0900h
    lea dx, msg_error
    int 21h
    mov ax, cx
    cld
    lea di, _buf
    call h4
    mov ax, 0900h
    lea dx, _buf
    int 21h
    ret ; TODO jump to some clear procedure

open_file: ; offset of filename should be in dx
    push ax
    mov ah, 3Dh
    xor al, al
    int 21h
    jc open_error
    mov handle, ax ; store file handle
    pop ax
    ret

close_file:
    push ax
    push bx
    mov bx, handle
    mov ah, 3Eh
    int 21h
    jc close_error
    pop bx
    pop ax
    ret

clear_text:
    push ax
    push cx
    push di
    cld
    xor al, al
    lea di, _txt
    mov cx, 160
rep stosb
    pop ax
    pop cx
    pop di

h8:
    push eax
    shr eax, 10h
    call h4
    pop eax
h4: ; ax as hex word
    xchg ah, al
    call h2
    xchg ah, al
h2: ; al as hex
    push ax
    push cx
    mov cl, 4
    shr al, cl
    pop cx
    call h1
    pop ax
h1: ; some magic to translate low nybble in al to hex
    push ax
    and al, 0Fh
    cmp al, 10
    sbb al, 69h
    das
    stosb
    pop ax
    ret

end _

; :build
; @tasm /m/l pci0.bat
; @tlink /x/t pci0
