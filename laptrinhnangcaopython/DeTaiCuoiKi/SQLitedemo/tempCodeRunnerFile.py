import tkinter as tk

def open_player_section():
  # Create the second window (player section)
  player_window = tk.Tk()
  player_window.title("Go to Player Section")

  # Set window size (optional, adjust as needed)
  player_window.geometry("400x200")

  # Create a welcome message label
  welcome_label = tk.Label(player_window, text="Welcome newcomer!\nFirst off, you need to start your team!", font=("Arial", 18))
  welcome_label.pack(pady=20)

  # Add a "Move to Player Management" button (customizable functionality)
  move_button = tk.Button(player_window, text="Move to Player Management", command=player_window.destroy)  # Replace with desired action
  move_button.pack(pady=10)

  # Run the main event loop for the player window
  player_window.mainloop()

def continue_clicked():
  window.destroy()  # Close the welcome window
  open_player_section()  # Open the player section window

# Create the main window
window = tk.Tk()
window.title("Welcome to Football Manager")

# Set window size (optional, adjust as needed)
window.geometry("500x300")

# Create a welcome message label
welcome_label = tk.Label(window, text="Welcome to Football Manager!", font=("Arial", 24))
welcome_label.pack(pady=50)

# Create a "Continue" button
continue_button = tk.Button(window, text="Continue", command=continue_clicked)
continue_button.pack(pady=20)

# Run the main event loop
window.mainloop()