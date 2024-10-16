# Assign 1 - Calculator
Design and implement a program to evaluate mathematical expressions typed by the user. For
example, if the user typed:

5 + 2 * -3 + (12.4 – 7.6) * 10 / 2

Your program would print the result:
23

---
Start by creating a UML diagram outlining your planned design for the assignment.
Retrieve the assignment starter code

The starter code includes a simple application that reads user input until the user types the
command “exit”. The ProcessCommand() function indicates where you should place your code
to evaluate the given math expression. Create supporting classes and methods as needed, but
keep the ProcessCommand() function, since it is used for running unit tests.

Your program should be able to:
  1. Handle addition, subtraction, multiplication, and division.
  2. Evaluate expressions with a single operation (ie: 1+2).
  3. Evaluate larger expressions with multiple operations (ie: 1*2-3+4).
  4. Perform operations in the correct order of operations (ie 2+3*4 is 14 not20).
  5. Ignore whitespace in the expression.
  6. Handle negative numbers.
  7. Handle numbers with a decimal.
  8. Handle brackets (ie: (2+3)*4 is 20).
  9. Handle nested brackets.
     
When you are finished, update your UML diagram to reflect your final program.
