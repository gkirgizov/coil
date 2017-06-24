; @goto compile
    model tiny
    .code
    org 100h

_:  jmp start
 
buf		db '__',13,10,'$'
show_is_over	db 0
old_int09	dd 0
 
int9_handler:
	push ax

	in	al, 60h		; get keyboard data from port A (60h)
	cmp	al, 1		;
	jne	handle_scancode	;
	mov	show_is_over, 1	; handle escape key
handle_scancode:
	call	print_hex	; print scan code
	in	al, 61h		; ack to keyboard
	mov	ah, al		; set and reset
	or	al, 80h		;   byte 7
	out	61h, al		;   in port B (61h)
	xchg	ah, al		;
	out	61h, al		;
	mov	al, 20h		; end of interrupt
	out	20h, al		;
	pop	ax
	iret

start:     
        push    0
        pop     es
        mov     bx, 36		; old int09 handler
        mov     ax, [es:bx]	;   save it
        mov     cx, [es:bx + 2]
        mov     word ptr old_int09, ax
        mov     word ptr old_int09 + 2, cx

        cli
        push    cs		; new int09 handler
        pop     ax
        mov     [es:bx], offset int9_handler
        mov     [es:bx + 2], ax
        sti
key_loop:
	cmp	show_is_over, 1
	jne	key_loop
exit:
        push    0
        pop     es
        cli
        ; restore int9 handler
        mov     bx, 24h ; 24h = 36 = 9 * 4
        mov     ax, word ptr [old_int09]
        mov     cx, word ptr [old_int09 + 2]
        mov     [es:bx], ax
        mov     [es:bx + 2], cx
        sti
    	ret

print_hex: ; print al as hex
	push	di
	push	es
	push	dx
	push	ax

	push	ds
	pop	es
	lea	di, buf
	call	h2
	lea	dx, buf
	mov	ax, 0900h
	int	21h
	
	pop	ax
	pop	dx
	pop	es
	pop	di
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

; :compile
; @tasm /m	kbrd9int.bat
; @tlink /x/t	kbrd9int
