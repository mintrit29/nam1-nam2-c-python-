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

void SearchStandFor(NODE *&pRoot, NODE *&p)
{
    if (pRoot->pRight)
        SearchStandFor(pRoot->pRight, p);
    else
    {
        p->Key = pRoot->Key;
        p = pRoot;
        pRoot = pRoot->pLeft;
    }
}
void Remove(NODE *&pRoot, int x)
{
    NODE *p;
    if (pRoot == NULL)
    {
        return;
    }
    if (x < pRoot->Key)
        Remove(pRoot->pLeft, x);
    else if (x > pRoot->Key)
        Remove(pRoot->pRight, x);
    else
    {
        // tim thay node can xoa
        p = pRoot;
        if (p->pRight == NULL)
            pRoot = p->pLeft;
        else if (p->pLeft == NULL)
            pRoot = p->pRight;
        delete p;
    }
}

int SumTree(NODE *pRoot)
{
    if (pRoot != NULL)
    {
        return pRoot->Key + SumTree(pRoot->pLeft) + SumTree(pRoot->pRight);
    }
    else
    {
        return 0;
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