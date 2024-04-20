#Inheritance(tính kế thừa)
class Product:
    def __init__(self, name, price):
        self.name = name
        self.price = price
    def get_data(self):
        self.name = input('Enter product name')
        self.price = input('Enter product price')
    def put_data(self):
        print(self.name)
        print(self.price)

class DigitalProduct(Product):
    def __init__(self,link):
        self.link = link
    def get_link(self):
        self.link = input('Enter link to product')
    def put_link(self):
        print(self.link)

ebook = DigitalProduct("")
ebook.get_data()
ebook.get_link()
ebook.put_data()
ebook.put_link()