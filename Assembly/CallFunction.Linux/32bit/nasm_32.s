global multiply_me

multiply_me:

	mov eax, [esp+4]
	mov edx, [esp+8]	 
	mul edx	
	mov edx, [esp+12]	 
	mul edx	
	mov edx, [esp+16]	 
	mul edx	
	mov edx, [esp+20]	 
	mul edx	
	mov edx, [esp+24]	 
	mul edx	
	ret				
