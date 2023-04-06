import tkinter as tk
import threading

def Draw():
    frame=tk.Frame(root,width=100,height=100,relief='solid',bd=1)
    frame.place(x=10,y=10)
    text=tk.Label(frame,text='HELLO')
    text.pack()

def Refresher():
    print('refreshing')
    Draw()
    threading.Timer(10, Refresher).start()

root=tk.Tk()
Refresher()
root.mainloop()