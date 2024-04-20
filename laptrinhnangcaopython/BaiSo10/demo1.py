x = [18.06, 15.57, 2.00, 1.27, 17.58, 17.19, 0.55, 6.03]
w = [-0.10, -0.20, -0.92, 0.31, 0.10, -0.54, 0.90, 0.88]

weighted_sum = sum(xi * wi for xi, wi in zip(x, w))
print("Weighted sum of x values:", weighted_sum)
