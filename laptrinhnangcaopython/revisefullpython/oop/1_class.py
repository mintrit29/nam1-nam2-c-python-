class Product:
    quantity = 400

    def __init__(self,name,price):
        self.name = name
        self.price = price
    def summer_discount(self,discount_percent):
        self.price = self.price - self.price * discount_percent/100

p1 = Product('laptop',300)
p1.summer_discount(9)
print(p1.name)
print(p1.price)