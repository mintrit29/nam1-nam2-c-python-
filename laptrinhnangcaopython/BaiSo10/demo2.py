def plant_time(season, temp):
    if season in ["spring", "autumn"]:
        return "You can plant"
    elif season == "summer" and 50 <= temp <= 80:
        return "You can plant"
    elif season == "winter":
        return "Do not plant"
    else:
        return "Do not plant"

# Example usage:
season = input("Enter current season: ")
temp = int(input("Enter temperature in Fahrenheit: "))
print(plant_time(season.lower(), temp))
