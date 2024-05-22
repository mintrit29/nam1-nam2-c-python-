#include <iostream>
#include <stdio.h>
using namespace std;

struct node
{
    int data; // du lieu cua node =>> du lieu se luu tru
    struct node *pLeft;
    struct node *pRight;
};
typedef struct node NODE;
typedef NODE *TREE;
// khoi tao cay
void KhoiTaoCay(TREE &t)
{
    t = NULL; // cay rong
}
// ham them phan tu x vao cay
void ThemNodeVaoCay(TREE &t, int x)
{
    if (t == NULL)
    {
        NODE *p = new NODE; // khoi tao node
        p->data = x;
        p->pLeft = NULL;
        p->pRight = NULL;
        t = p;
    }
    else
    {
        if (t->data > x)
        {
            ThemNodeVaoCay(t->pLeft, x);
        }
        else if (t->data < x)
        {
            ThemNodeVaoCay(t->pRight, x);
        }
    }
}
// ham xuat cay nhi phan theo NLR
void Duyet_NLR(TREE t)
{
    if (t != NULL)
    {
        cout << t->data << " ";
        Duyet_NLR(t->pLeft);
        Duyet_NLR(t->pRight);
    }
}
// ham xuat cay nhi phan theo NRL
void Duyet_NRL(TREE t)
{
    if (t != NULL)
    {
        cout << t->data << " ";
        Duyet_NRL(t->pRight);
        Duyet_NRL(t->pLeft);
    }
}
// ham xuat cay nhi phan theo LNR
void Duyet_LNR(TREE t)
{
    if (t != NULL)
    {
        Duyet_LNR(t->pLeft);
        cout << t->data << " ";
        Duyet_LNR(t->pRight);
    }
}
// ham xuat cay nhi phan theo RNL
void Duyet_RNL(TREE t)
{
    if (t != NULL)
    {
        Duyet_RNL(t->pRight);
        cout << t->data << " ";
        Duyet_RNL(t->pLeft);
    }
}
// ham xuat cay nhi phan theo LRN
// ham xuat cay nhi phan theo RLN
// ham nhap du lieu
// neu node co ton tai trong cay thi tra ve node do, neu ko tra ve NULL
NODE *TimKiem(TREE t, int x)
{
    if (t == NULL)
    {
        return NULL; // Not found
    }
    else
    {
        if (x < t->data)
        {
            return TimKiem(t->pLeft, x); // Return the result of the recursive call
        }
        else if (x > t->data)
        {
            return TimKiem(t->pRight, x); // Return the result of the recursive call
        }
        else
        {             // t->data == x
            return t; // Found
        }
    }
}

void Menu(TREE &t)
{
    while (true)
    {
        cout << "\n--Menu--";
        cout << "\n1.Nhap du lieu";
        cout << "\n2.Xuat du lieu cay theo NLR";
        cout << "\n3.Xuat du lieu cay theo NRL";
        cout << "\n4.Xuat du lieu cay theo LNR";
        cout << "\n5.Xuat du lieu cay theo RNL";
        cout << "\n6.Tim kiem Node";
        cout << "\n0.Ket thuc chuong trinh";

        int luachon;
        cout << "\nNhap lua chon: ";
        cin >> luachon;
        if (luachon < 0 || luachon > 6)
        {
            cout << "\nLua chon khong hop le";
            system("pause");
        }
        else if (luachon == 1)
        {
            int x;
            cout << "\nNhap so nguyen x";
            cin >> x;
            ThemNodeVaoCay(t, x);
        }
        else if (luachon == 2)
        {
            cout << "\nDuyet cay theo NLR: \n";
            Duyet_NLR(t);
        }
        else if (luachon == 3)
        {
            cout << "\nDuyet cay theo NRL: \n";
            Duyet_NRL(t);
        }
        else if (luachon == 4)
        {
            cout << "\nDuyet cay theo LNR: \n";
            Duyet_LNR(t);
        }
        else if (luachon == 5)
        {
            cout << "\nDuyet cay theo RNL: \n";
            Duyet_RNL(t);
        }
        else if (luachon == 6)
        {
            int x;
            cout << "\n Nhap phan tu can tim: ";
            cin >> x;
            NODE *p = TimKiem(t, x);
            if (p == NULL)
            {
                cout << "\nPhan tu " << x << " khong ton tai trong cay";
            }
            else
            {
                cout << "\nPhan tu " << x << " ton tai trong cay";
            }
            system("pause");
        }
        else
        {
            break;
        }
    }
}

int main()
{
    TREE t;
    KhoiTaoCay(t);
    Menu(t);
    system("pause");
    return 0;
}