#include <iostream>
using namespace std;

void NhapMang(int a[], int &n)
{
    cout << "Nhap so phan tu mang: ";
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        cout << "a[" << i << "]: ";
        cin >> a[i];
    }
}

void ThemX(int a[], int &n, int x, int k)
{
    if (k < 0 || k > n)
    { // kiểm tra vị trí k hợp lệ
        cout << "Vi tri k khong hop le!\n";
        return;
    }

    // Dời các phần tử từ vị trí k đến vị trí cuối mảng sang phải 1 đơn vị
    for (int i = n; i > k; i--)
    {
        a[i] = a[i - 1];
    }

    // Thêm giá trị x vào vị trí k
    a[k] = x;

    // Tăng số phần tử của mảng lên 1
    n++;

    // In ra mảng sau khi thêm giá trị x vào vị trí k
    cout << "Mang sau khi them " << x << " vao vi tri " << k << " la: ";
    for (int i = 0; i < n; i++)
    {
        cout << a[i] << " ";
    }
    cout << endl;
}

int main()
{
    int a[100], n, x, k;
    NhapMang(a, n);

    cout << "Nhap gia tri can them: ";
    cin >> x;
    cout << "Nhap vi tri can them (0 <= k <= " << n << "): ";
    cin >> k;

    ThemX(a, n, x, k);

    return 0;
}