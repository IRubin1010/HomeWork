//bootstrap
@256
D=A
@SP
M=D

//push constant 0
@0
D=A
@SP
A=M
M=D
@SP
M=M+1

//pop local 0
@LCL
D=M
@0
D=D+A
@13
M=D
@SP
M=M-1
A=M
D=M
@13
A=M
M=D

//label LOOP_START
(BasicLoop.LOOP_START)

//push argument 0
@0
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//push local 0
@0
D=A
@LCL
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//add
@SP
M=M-1
A=M
D=M
A=A-1
M=M+D

//pop local 0
@LCL
D=M
@0
D=D+A
@13
M=D
@SP
M=M-1
A=M
D=M
@13
A=M
M=D

//push argument 0
@0
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//push constant 1
@1
D=A
@SP
A=M
M=D
@SP
M=M+1

//sub
@SP
M=M-1
A=M
D=M
A=A-1
M=M-D

//pop argument 0
@ARG
D=M
@0
D=D+A
@13
M=D
@SP
M=M-1
A=M
D=M
@13
A=M
M=D

//push argument 0
@0
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//if-goto LOOP_START
@SP
M=M-1
A=M
D=M
@BasicLoop.LOOP_START
D; JNE

//push local 0
@0
D=A
@LCL
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D
