people = {'Triet':19,'Minh':20,'Vincent':21}
people_id = {1:'Triet',2:'Minh',3:'Vincent'}
print(people)
print(people['Minh'])
print(people_id[3])

#Mutable Dictionary
people = {
    'Triet':19,
    'Minh':20,
    'Vincent':21
}
people['Minh'] = 30
print(people)

#Dict functions
people = dict(
    Triet = 19,
    Minh = 20,
    Vincent = 21
)
people['minhtong'] = 25
del people['Minh']
print(people)

#Get methods
people = dict(
    Triet = 19,
    Minh = 20,
    Vincent = 21
)
print(people.get('Triet'))
#print(people['Vinh']) #if thí idividual dóe not in dict, return error
print(people.get('Vinh'))#if this individual does not in dict, return None

#Update and pop method
#update method
prices = {'iphone':500,'ipad':400}
new_prices = {'iphone':600,'imac':1500}
prices.update(new_prices)
print(prices)
#pop method
prices = {'iphone':500,'ipad':400}
prices.pop('ipad')
print(prices)

#Items and keys method
prices = {'iphone':500,'ipad':400,'imac':1500}
print(prices.values())
print(prices.keys())
print(prices.items())

#Adding product to dictionary
products = {'phone':100,'tablet':200,'laptop':400,'journal':40}
print(products)
product = input('Enter product to check the price: ')
print(f'Price of the {product} is {products[product]}')

new_product = input('Enter product you want to add: ')
new_product_price = input('Enter price for the product: ')
products[new_product] = new_product_price
print(f'Product added successfully, here is an updated list of products {products}')

#Removing product from dictionary
del_product = input('Enter product you want to delete: ')
del products[del_product]
print(f'Product deleted successfully, here is an updated list of products {products}')

#Editing product from dictionary
edit_product = input('Enter product you want to edit: ')
new_product_price = input('Enter price for {edit_product}: ')
products[edit_product] = new_product_price
print(f'Product edited successfully, here is an updated list of products {products}')