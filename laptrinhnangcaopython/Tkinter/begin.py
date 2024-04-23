import tkinter
from tkinter import messagebox
#khai bao form chinh
root = tkinter.Tk()
#them widget
tkinter.Label(root, 
    text="Hello, world!",
    font="Arial 18",
    bg="yellow green",
    fg="red",
).pack()
tkinter.Label(root, text="Phan Mem Quan Ly").pack()
tkinter.Button(root, 
    text="Lick me!",
    command=lambda : messagebox.showinfo("Thong bao","Vua click")
).pack()
#hien form
root.mainloop()