global multiply_me

multiply_me:

	mov rax, rdi
	imul rax, rsi
	imul rax, rdx
	imul rax, rcx
	imul rax, r8
	imul rax, r9
	ret
