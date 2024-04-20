#Adding item to cart using While loop hardcore
cart =[]
products = [
    {'name': 'Laptop','price':300},
    {'name':'Ipad','price':100},
    {'name':'IPhone','price':250}
]
while True:
    choice = input('Do you want to continue shopping? ')
    if choice == 'yes':
        print('Here is the list of products and their prices')
        for index,product in enumerate(products):
            print(f'{index}:{product['name']}:{product['price']}')
        product_id = int(input('Choose the id of the product you want to buy'))
        #check if the product already exists in cart
        if products[product_id] in cart:
            products[product_id]['quantity'] += 1
        else:
            products[product_id]['quantity'] = 1
            cart.append(products[product_id])
        total = 0
        for product in cart:
            print(f'{product["name"]}:{product["price"]}: QTY:{product['quantity']}')
            total = total + product['price']*product['quantity']
        print(f'Total price: {total}$')
    else:
        break
print(f'Here is the list of products you have added to cart {cart}')