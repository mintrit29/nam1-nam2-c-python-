#from dict to json string
import json
data = {
    'name':'John Smith',
    'age':30,
    'city':'Mountain'
}
json_data = json.dumps(data)
print(json_data)

#from json string to dict
json_data = '{"name": "John Smith", "age": 30, "city": "Mountain"}'
data = json.loads(json_data)
print(type(data))
print(data)
print(data['name'])