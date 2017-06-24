; @echo off
; @goto make
	.model tiny
	.386
	.code
	org 100h
_:
	jmp 	start

buf	db	'____:____',13,10,'$'
bp_comm	db	0
bp_int	db	0CCh	; breakpoint opcode (int 3)

prgname	db	'hw.com',0
hlp_msg	db	"Press Enter to make step (next command).",13,10,'$'
err_msg	db	"Error reading file.",13,10,'$'
end_msg	db	"Re-run program? (y/n)",13,10,'$'
bp_msg1	db	"Breakepoint at ",'$'

int1_handler:
	push	bp
	mov	bp, sp		; for print_hex (next ip of program)
	push	ax
	push	bx
	push	di
	push	es
	push	ds
	push	cs		; loading data segment
	pop	ds		;   to be able to access our data

	call	print_hex	
	sti			; set interrupts for main loop
ui_trace:
	xor	ax, ax
	int	16h
	cmp	ah, 1Ch		; Enter
	je	trace_step
	jmp	ui_trace
trace_step:
	pop	ds
	pop	es
	pop	di
	pop	bx
	pop	ax
	pop	bp
	iret

int3_handler:
	push	bp
	mov	bp, sp	; addr of replaced command
	push	ax
	push	dx
	push	di
	push	es
	push	ds
	push 	cs
	pop	ds

	mov	ah, 9
	lea	dx, bp_msg1
	int	21h
	call	print_hex

	; replace byte to original
	mov	es, [bp + 4]	  ; original cs
	dec	word ptr [bp + 2] ; dec ip to point again to original byte
	mov	di, [bp + 2]
	mov	al, bp_comm
	mov	byte ptr [es:di], al

	mov	ax, 2501h
	lea	dx, int1_handler
	int	21h
	
	pop	ds
	pop	es
	pop	di
	pop	dx
	pop	ax
	pop	bp
	iret
	
print_hex: ; write dword stored in bp to buf in hex and print buf
	push	ax
	push	dx
	push	di
	
	call	h8	; write segm:offs to buf
	mov	ah, 9
	lea	dx, buf
	int	21h

	pop	di
	pop	dx
	pop	ax
	ret

h8:	; write segment:offset stored in bp to buf in hex form
	lea	di, buf
	mov	ax, [bp + 4]	; segment
	call	h4
	inc	di
	mov	ax, [bp + 2]	; offset
h4:	; ax as hex word
	xchg	ah, al
	call	h2
	xchg	ah, al
h2:	; al as hex
	push	ax
	push	cx
	mov	cl, 4
	shr	al, cl
	pop	cx
	call	h1
	pop	ax
h1:	; some magic to translate low nybble in al to hex
	push	ax
	and	al, 0Fh
	cmp	al, 10
	sbb	al, 69h
	das
	stosb
	pop	ax
	ret

start:
	mov	ah, 9
	lea	dx, hlp_msg
	int	21h

	mov	ax, 3D00h	; DOS - open file
	lea	dx, prgname
	int	21h
	jc	error_open
	mov	bx, ax
	mov	ah, 3Fh		; DOS - read from file
	mov	cx, 100h
	lea	dx, prog
	int	21h
	jc	error_open
	mov	ah, 3Eh		; DOS - close file
	int	21h	
init_program:
	pushf			; flags for second iret
	push	cs		;
	lea	ax, after_debug	;
	push	ax		; cs for second iret
	push	0		; ip for second iret

	pushf			;
	pop	ax		;
	or	ax, 0100h	; set Trap Flag
	push	ax		; flags for first iret

	lea	ax, psp_start
	shr	ax, 4
	mov	bx, cs
	add	ax, bx		; get segment addr (psp>>4 + cs)
;	mov	ds, ax		; WRONG
;	mov	es, ax		; WRONG
	push	ax		; cs for first iret
	push	100h		; ip for first iret

	push	ax		; something important here (1.1)
	mov	ax, 2503h	; set int3 handler
	lea	dx, int3_handler
	int	21h
;	pop	ds		; something important here (1.2)
	
	; set breakpoint in program
	mov	al, byte ptr [prog + 0]
	mov	byte ptr [bp_comm], al
	mov	al, bp_int
	mov	byte ptr [prog + 0], al

	pop	ds
	iret
	; after first iret we have 
	; TF set (int1 after each command),
	; cs pointing to psp buffer (i.e. PSP for loaded program),
	; ip pointing to prog buffer (i.e. to code of loaded program)
	; and after terminate of prog we have 0CFh - second iret
	;   instead of int 20h (at the beginning of psp)
	; second iret allows us to return back to that debugger,
	;   not just terminate loaded program and go to DOS.

after_debug:
	push	cs
	pop	ds
	lea	dx, end_msg
	mov	ah, 09h
	int	21h
ui_exit:
	xor	ax, ax
	int	16h
	cmp	ah, 15h	; 'y'
	je	init_program
	cmp	ah, 31h	; 'n'
	je	exit
	jmp	ui_exit
exit:	
	ret			; final return from debugger

error_open:	; handle open file error
	lea	dx, err_msg
	mov	ah, 9
	int	21h
	ret

align	16
psp_start	db	0CFh	; iret replaces int 20h in the psp
psp		db	(100h - (psp - psp_start)) dup(0)
prog		db	100h dup(0)
end _

; :make
;	@tasm /m5 debughw1.bat
;	@tlink /x /t debughw1