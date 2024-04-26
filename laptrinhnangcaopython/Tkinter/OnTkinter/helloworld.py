from tkinter import *

def display():
    data = entry.get()
    print(data)

root = Tk()
root.geometry('300x400')

entry = Entry(root)
entry.pack()

label = Label(root, text='Cua Hang Mua Cau Thu',
    fg='blue',
    bg='pink',
    font=('JetBrains Mono Italic',14)
)
label.pack()

button = Button(root, 
    text='Buy',
    command=display
)
button.pack()

root.mainloop()