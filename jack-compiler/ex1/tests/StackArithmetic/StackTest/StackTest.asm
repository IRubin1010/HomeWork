//bootstrap
@256
D=A
@SP
M=D

//push constant 17
@17
D=A
@SP
A=M
M=D
@SP
M=M+1

//push constant 17
@17
D=A
@SP
A=M
M=D
@SP
M=M+1

//eq
@SP
M=M-1
A=M
D=M
A=A-1
D=M-D
@LABEL_0
D;JEQ
@SP
A=M-1
M=0
@END_0
0;JMP
(LABEL_0)
@SP
A=M-1
M=-1
(END_0)
 
//push constant 892
@892
D=A
@SP
A=M
M=D
@SP
M=M+1

//push constant 891
@891
D=A
@SP
A=M
M=D
@SP
M=M+1

//lt
@SP
M=M-1
A=M
D=M
A=A-1
D=M-D
@LABEL_1
D;JLT
@SP
A=M-1
M=0
@END_1
0;JMP
(LABEL_1)
@SP
A=M-1
M=-1
(END_1)
 
//push constant 32767
@32767
D=A
@SP
A=M
M=D
@SP
M=M+1

//push constant 32766
@32766
D=A
@SP
A=M
M=D
@SP
M=M+1

//gt
@SP
M=M-1
A=M
D=M
A=A-1
D=M-D
@LABEL_2
D;JGT
@SP
A=M-1
M=0
@END_2
0;JMP
(LABEL_2)
@SP
A=M-1
M=-1
(END_2)
 
//push constant 56
@56
D=A
@SP
A=M
M=D
@SP
M=M+1

//push constant 31
@31
D=A
@SP
A=M
M=D
@SP
M=M+1

//push constant 53
@53
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

//push constant 112
@112
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

//neg
@SP
A=M
A=A-1
M=-M

//and
@SP
M=M-1
A=M
D=M
A=A-1
M=M&D

//push constant 82
@82
D=A
@SP
A=M
M=D
@SP
M=M+1

//or
@SP
M=M-1
A=M
D=M
A=A-1
M=M|D
