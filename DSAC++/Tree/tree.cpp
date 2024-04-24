#include <stdio.h>
using namespace std;

struct NODE 
{
    int key;
    NODE *left;
    NODE *right;
};

void init(NODE *&TREE)
{
    TREE = NULL;
}

void insert(NODE *&pRoot, int x)
{
    if (pRoot == NULL)
    {
        NODE *q;
        q = new NODE;
        q->key = x;


}