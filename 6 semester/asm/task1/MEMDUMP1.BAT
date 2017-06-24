; @goto build
	.model tiny
	.386
	.code
	org 100h
_:
	xor	bx, bx	; set ds and bx to zero
	mov	ds, bx
	xor	ah, ah	; set video mode 
	mov	al, 3	; (80 * 25 text mode)
	int	10h
	jmp	print_screen
main:
	xor	ax, ax
	int	16h	; wait for keyboard (scan code at ah)
	cmp	ah, 48h	; Key Up
	je	up
	cmp	ah, 50h	; Key Down
	je	down
	cmp	ah, 49h	; Page Up
	je	pgup
	cmp	ah, 51h	; Page Down
	je	pgdn
	jmp	main
up:
	sub	bx, 10h
	jmp	print_screen
down:
	add	bx, 10h
	jmp	print_screen
pgup:
	mov	ax, ds
	dec	ax
	mov	ds, ax
	jmp	print_screen
pgdn:
	mov	ax, ds
	inc	ax
	mov	ds, ax
	jmp	print_screen

print_screen:			; print ds:bx 
	push	bx
	push	ds
	mov	ax, 0b800h	; 0b800h - start of video memory
	mov	es, ax
	xor	di, di
   	mov	dx, 160	; line is 160 bytes (80 ASCII)
   	mov	cx, 25	; loop on 25 lines
   	cld		; clear direction flag
line:
	call	print_line
	mov	di, dx
	add	dx, 160
	loop	line
	pop	ds
	pop	bx
	jmp	main

print_line: 		; prints bytes from ds:bx up to ds:bx+16
	mov	ax, ds		; print ds
	call	print_word_hex
	mov	al, ':'
	mov	ah, 0Fh
	stosw
	mov	ax, bx		; print bx
	call	print_word_hex
	add	di, 2 		; space
	mov	al, '-'
	mov	ah, 0Fh
	stosw
	add	di, 2
	push	cx
	mov	cx, 8
data_word_lp:
	mov	ax, word ptr [ds:bx]
	xchg	ah, al
	call	print_word_hex
	xor	ax, ax
	stosw		; print space
	add	bx, 2	; next word
	loop	data_word_lp
	pop	cx
	ret

print_word_hex: 	; print ax to es:di (video mem)
	push	ax
	xchg	ah, al
	call	print_al
	pop	ax
	call	print_al
	ret

print_al:
	push	ax
	push	cx
	mov	cl, 4	; shift by 4 to get high nybble
	shr	al, cl
	pop	cx
	call	print_digit
	pop	ax	; print low nybble
	call	print_digit
	ret

print_digit:
	push	ax
    and al, 0Fh    	; clear CF
    cmp al, 10		; if al > 10, then CF := 1
    sbb al, 69h		; al := al - 69h ( - 1, if CF == 1)
    das			; das maintains AL as decimal number
	mov	ah, 0Fh
	stosw
	pop	ax
	ret

the_end:
	db	(510 - (the_end - _)) dup(0)
	db	55h, 0AAh
end _

; :build
;	@tasm /m memdump1.bat
;	@tlink /x /t memdump1
