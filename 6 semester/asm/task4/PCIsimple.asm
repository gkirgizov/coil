; goto blt
	.model tiny
	.386
	.code
	org 100h
_:	jmp start
vid	db "v:0000 "
did	db "d:0000 "
class	db "cl:00 "
sclass	db "scl:00 "
pif	db "pif:00 ",13,10,'$'
tmp1	dd 0
start:	
	xor bx,bx
lp1:
	xor di,di
	mov ax, 0B10Ah	
	int 1Ah
	jc nxt
	cmp ecx, 0ffffffffh
	jz nxt
	mov tmp1, ecx
	mov ax, 0b10Ah
	mov di,8
	int 1Ah
	cmp ecx, 0ffffffffh
	jz nxt

	mov edx, ecx
	push di
	push ax
	lea di,	vid+2
	mov eax, tmp1 
	call h4

	lea di, did+2
	shr eax, 16
	call h4

	lea di, class+3
	ror edx,16
	mov al, dh 
	call h2

	lea di, sclass+4
	mov al, dl
	call h2

	ror edx,16
	mov al, dh
	lea di, pif+4

	call h2	
	lea dx, vid

	mov ah,09h
	int 21h	
	pop ax
	pop di
nxt:
	inc bx
	cmp bx, 0ffffh
	jb lp1
	
	ret
h4:  xchg ah,al
  call h2
  xchg ah,al
h2:  push ax
  push cx
  mov cl,4
  shr al,cl
  pop cx
  call h1
  pop ax
h1:  push ax
  and al,0Fh
  cmp al,10
  sbb al,69h
  das
  stosb
  pop ax
  ret
end _
; :blt
; tasm /m pci.bat
; tlink /x/t pci.obj
