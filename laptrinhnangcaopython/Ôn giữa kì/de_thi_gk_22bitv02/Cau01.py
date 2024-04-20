def myfunc(n):
    M = set({1,1,2,3,2})
    P = M
    print(M)
    M.add(n)
    print(P)
    Q = P.intersection(set({n,3,4}))
    print(Q)
    P.clear()
    print(P)
    return [M, P, Q]
print(myfunc(0))