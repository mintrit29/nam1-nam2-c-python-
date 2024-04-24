#include <stdio.h>
#include <iostream>
using namespace std;

struct NODE
{
    int Key;
    NODE *pLeft;
    NODE *pRight;
};

NODE *CreateNode(int x);
void Init(NODE *&pRoot);
void Insert(NODE &pRoot, int x);
void NLR(NODE &pRoot);

NODE *CreateNode(int x)
{
    NODE *pNode = new NODE;
    pNode->Key = x;
    pNode->pLeft = pNode->pRight = NULL;
    return pNode;
}
void Init(NODE *&pRoot)
{
    pRoot = NULL;
}
void Insert(NODE *&pRoot, int x)
{
    if (pRoot == NULL)
    {
        pRoot = CreateNode(x);
    }
    else
    {
        if (x < pRoot->Key)
        {
            Insert(pRoot->pLeft, x);
        }
        else if (x > pRoot->Key)
        {
            Insert(pRoot->pRight, x);
        }
        else
        {
            return;
        }
    }
}
void NLR(NODE *&pRoot)
{
    if (pRoot != NULL)
    {
        // in gia tri cua root
        cout << pRoot->Key << " ";
        // duyet nhanh trai
        NLR(pRoot->pLeft);
        // duyet nhanh phai
        NLR(pRoot->pRight);
    }
}

int main()
{
    NODE *pRoot;
    Init(pRoot);
    int x;
    while (cin >> x)
    {
        Insert(pRoot, x);
        NLR(pRoot);
        cout << endl;
    }
    return 0;
}