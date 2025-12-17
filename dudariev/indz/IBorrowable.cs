namespace indz
{
    public interface IBorrowable<TSelf, TBorrower>
        where TSelf : class, IBorrowable<TSelf, TBorrower>
        where TBorrower : class, IBorrower<TBorrower, TSelf>
    {
        TBorrower? Borrower { get; set; }
    }
}
