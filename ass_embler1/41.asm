;41 (a*b/4-1)/(41-b*a+c)
section .data
    msg db 'Результат: %ld', 0xA, 0
    a dq 2
    b dq 3
    c dq 4
section .text
    extern printf
    global _start
.code
main proc
    mov rax, [a]
    mul qword [b]
    mov rdx, 0
    mov rdi, 4
    div rdi
    dec rax
    mov rdi, rax
    mov rax, [b]
    mul qword [a]
    mov r8, 41
    sub r8, rax
    add r8, [c]
    cmp r8, 0
    je zero_division
    mov rax, rdi
    mov rdx, 0
    div r8
    mov rdi, msg
    mov rsi, rax
    call printf
    mov rax, 60
    xor rdi, rdi
    syscall
    mov rax, 60
    mov rdi, 1
    syscall
main endp
end