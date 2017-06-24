; @goto build
    model tiny
    .code
    .386
    org 100h
_:  jmp start

buf db '1234abcd'
prt db 'xxxxxxxx',13,10,'$'

start:
    mov eax, dword ptr[buf]
    cld
    lea di, prt
    call h8

    mov ax, 0900h
    lea dx, prt
    int 21h
    
    ret

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
