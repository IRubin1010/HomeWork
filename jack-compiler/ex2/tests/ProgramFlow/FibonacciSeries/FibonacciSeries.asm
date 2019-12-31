//bootstrap
@256
D=A
@SP
M=D

//push argument 1
@1
D=A
@ARG
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//pop pointer 1
@SP
M=M-1
A=M
D=M
@4
M=D

//push constant 0
@0
D=A
@SP
A=M
M=D
@SP
M=M+1

//pop that 0
@THAT
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

//push constant 1
@1
D=A
@SP
A=M
M=D
@SP
M=M+1

//pop that 1
@THAT
D=M
@1
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

//push constant 2
@2
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

//label MAIN_LOOP_START
(FibonacciSeries.MAIN_LOOP_START)

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

//if-goto COMPUTE_ELEMENT
@SP
M=M-1
A=M
D=M
@FibonacciSeries.COMPUTE_ELEMENT
D; JNE

//goto END_PROGRAM
@FibonacciSeries.END_PROGRAM
0; JMP

//label COMPUTE_ELEMENT
(FibonacciSeries.COMPUTE_ELEMENT)

//push that 0
@0
D=A
@THAT
A=M
A=D+A
D=M
@SP
M=M+1
A=M-1
M=D

//push that 1
@1
D=A
@THAT
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

//pop that 2
@THAT
D=M
@2
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

//push pointer 1
@4
D=M
@SP
A=M
M=D
@SP
M=M+1

//push constant 1
@1
D=A
@SP
A=M
M=D
@SP
M=M+1

//add
@SP
M=M-1
A=M
D=M
A=A-1
M=M+D

//pop pointer 1
@SP
M=M-1
A=M
D=M
@4
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

//goto MAIN_LOOP_START
@FibonacciSeries.MAIN_LOOP_START
0; JMP

//label END_PROGRAM
(FibonacciSeries.END_PROGRAM)
