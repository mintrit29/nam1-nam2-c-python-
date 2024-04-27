from tkinter import *

root = Tk()

for x in range(5):
    for y in range(3):
        frame = Frame(root)
        frame.grid(row=x,column=y)
        button = Button(frame,text=f'Row {x}\n Column {y}')
        button.pack(padx=50,pady=50)
root.mainloop()