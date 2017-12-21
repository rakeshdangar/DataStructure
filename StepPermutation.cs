//int sum1(list<int> steps)
//{
//    int sum = 0;
//    for (list<int>::iterator it=steps.begin();it!=steps.end();it++)
//    {
//        sum+=*it;
//    }
//    return sum;
//}
//void permuteSteps(int n, list<int> steps)
//{
//    int sum = 0;
//    sum=sum1(steps);
//    cout << "Call for n=" << n<< " ; ";
//    cout << "sum: " << sum << endl;
//    if ( sum == n)
//    {
//        for (list<int>::iterator it=steps.begin();it!=steps.end();it++)
//        {
//            cout << *it <<" ";
//        }
//        cout << endl;
//        return;
//    }
//    else if (sum > n) return;

//    for (int i=1;i<=3;i++)
//    {
//        steps.push_back(i);
//        permuteSteps(n, steps);
//        steps.pop_back();
//    }
//}

//int main()
//{
//    int ar1[]={2,12,14,34,36};
//    int ar2[]={1,3,6,7,15,74};

//    list<int> steps;
//    permuteSteps(5, steps);
//    cout << "\n";
//    return 0;
//}