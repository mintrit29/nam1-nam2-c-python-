import json
def save_user_data():
    user_list=[]
    while True:
        name = input('Enter name or "quit" to exist the program: ')
        if name == 'quit':
            break
        email = input('Enter email: ')
        contact = input('Enter contact: ')
#creating a dictionary
        user_data = {
            'name':name,
            'email':email,
            'contact':contact
        }
        user_list.append(user_data)
        with open('user_data.json','w') as file:
            json.dump(user_list,file)
        print('Successfully saved')
save_user_data()