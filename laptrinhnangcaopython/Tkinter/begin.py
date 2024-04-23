import tkinter
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
tkinter.Button(root, text="Lick me!").pack()
#hien form
root.mainloop()