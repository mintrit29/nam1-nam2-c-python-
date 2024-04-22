import json,requests

api_end_point = 'https://dummyjson.com/products'

req = requests.get(api_end_point)
if req.status_code == 200: #success
    result = req.json()
    print(json.dumps(result,indent = 4))

    #Muốn lưu mảng product xuống file products.json
    #Mỗi product chỉ lấy id, tilte, price, thumbnail
    my_data = []
    for product in result['products']:
        my_data.append({
            'id': product['id'],
            'title': product['title'],
            'price': product['price'],
            'thumbnail': product['thumbnail']
        })

    with open('products.json', 'w', encoding='utf8') as my_file:
        json.dump(my_data, my_file, indent = 4)