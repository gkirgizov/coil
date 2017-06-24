; @goto make
    model tiny
    .code
    org 100h
 
_:	jmp key_loop
 
buf	db '__ ','$'
 
key_loop:
	xor	ax, ax
	int	16h
	cmp	ah, 1
   	je	exit
	call	print_key 
	jmp	key_loop
exit:
	ret
 
print_key:
	push	ax
	lea	di, buf	; print scan code
	xchg	ah, al	;   initially scan code in ah
	call	h2	;

	lea	dx, buf	;
	mov	ax, 0900h
	int	21h

	pop	ax	; ascii code (initially in al)
	mov	ah, 0Ah ;   print it (Write Char at Cursor BIOS func)
	mov	cx, 1	;
	int	10h	;

	mov	ah, 3	; get cursor
	int	10h	; 
	sub	dl, 3	; and set cursor pos - same pos
	add	dh, 1	;   and next row
	mov	ah, 2	;
	int	10h	;
	ret
 
h4: ; ax as hex word
	xchg	ah, al
	call	h2
	xchg	ah, al
h2: ; al as hex
	push	ax
	push	cx
	mov	cl, 4
	shr	al, cl
	pop	cx
	call	h1
	pop	ax
h1: ; some magic to translate low nybble in al to hex
	push	ax
	and	al, 0Fh
	cmp	al, 10
	sbb	al, 69h
	das
	stosb
	pop	ax
	ret
end _

; :make
; @tasm /m kbrd16.bat
; @tlink /x/t kbrd16
