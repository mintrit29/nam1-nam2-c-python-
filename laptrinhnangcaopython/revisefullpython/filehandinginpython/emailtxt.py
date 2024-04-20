def save_user_data():
    name = input('Enter your name')
    email = input('Enter your email address')
    contact = input('Enter your contact')
    user_data = f'Name: {name}\nEmail: {email}\nContact: {contact}\n'
    with open('user_data.txt','a') as file:
        file.write(user_data)
save_user_data()

def read_user_data():
    with open('user_data.txt','r') as file:
        print(file.read())
read_user_data()