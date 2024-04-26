from tkinter import *

def add():
    n1= int(Number1.get())
    n2= int(Number2.get())
    result = str(n1+n2)
    answer.config(text='Answer is: '+ result)

root = Tk()
root.geometry('300x400')

Number1 = Entry(root)
Number2 = Entry(root)

Number1.pack()
Number2.pack()

button = Button(root, text='Add',command=add)
button.pack()

answer = Label(root)
answer.pack()

root.mainloop()