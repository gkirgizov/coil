; @echo	off
; @goto	make
	.model tiny
	.386
	.code
	org 100h
_:
	jmp 	start
mes	db 	"Hello to hell.",13,10,'$'
start:	
	lea	dx, mes
	mov	ah, 09h
	int	21h
	ret
end _

; :make
;	@tasm /m /l hw.bat
;	@tlink /x /t hw