void Sleepsort(List<string> strings)
{
    object o = new object();

    var threads = new List<Thread>();
    foreach (var str in strings)
    {
        threads.Add(new Thread(() =>
        {
            Thread.Sleep(str.Length * 50);
            lock (o)
            {
                Console.WriteLine(str);
            }
        }));
    }

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }
}

LinkedList<string> SleepsortLinkedList(List<string> strings)
{
    var result = new LinkedList<string>();
    object o = new object();

    var head = new LinkedListNode<string>("");
    result.AddFirst(head);
    var lastAdded = head;

    var threads = new List<Thread>();
    foreach (var str in strings)
    {
        threads.Add(new Thread(() =>
        {
            Thread.Sleep(str.Length * 50);
            lock (o)
            {
                var node = new LinkedListNode<string>(str);
                result.AddAfter(lastAdded, node);
                lastAdded = node;
            }
        }));
    }

    foreach (var thread in threads)
    {
        thread.Start();
    }

    foreach (var thread in threads)
    {
        thread.Join();
    }

    result.Remove(head);
    return result;
}

var rawStrings = new List<string>
{
    "G2Xte8FcB8YM1Mts92i2QpnQYshNdgUbvcuKGr0x",
    "hfLI7ITJiSPSfwxMQnq1Lddq4ZbsdsUY5gh6tLHl",
    "hjg7P6jt8ZsgaQJzI8x8fv5Vou0e96VYPqAA0AmV",
    "pZsoo5nRtAHlMf05APiQN7DjXHuK9T3gIW8E1B2Z",
    "hzFFRzTq0KP64w4DdXxxiZiGKiEEO0vmuVpBP2CE",
    "U6FaeegnPBxJUWXVdtGSM6wRbdLXSZGduOWXJg5z",
    "wNlb6JscAPGdUG454BlPhIJPmeeR1MoAFpfgRTwP",
    "A1AWRItZmOBYMYJqaXP0fUkH3foYnuSBE5gmkplR",
    "2FtGs6ycd5c0ZRTTxdj6JR2as6CCsv7AeCq4z2Cs",
    "d6pRZXrRiGzDwhnWeQa43sT90AfoE5WlYhtVmVjI",
    "uODHrzaGRpfITdTrysoT46cRHLBsZqXSPLAaEhL5",
    "2aTO4iMbuiUsfzzIDkHIgkPosRYbMyrWA7MJxlAx",
    "AXWOMYafAH7CIG9yDfUD22Scul0sXPbdKAh0S4ov",
    "f17nzqS5OVcxUeuPtlIZIzOPuLZCYuidnn8oVAQV",
    "3YGRvXynrUP2qeiGiajBTXbeMYKlFNBpdu4SyczH",
    "io7fhf553ys8JAdfDQc73uDAc81OMdio3Q9G9Ot8",
    "ryMyhh2qHBATEA3nlnHDQt4OVcsu5jveAXXrrlOX",
    "EUtYLEipjOUS7mpDcuLZaHFFU2zzuh16EYOLcRS3",
    "k0xlMjyvD5FwJ8XCzPSIZAwdIuVrOODOqSx7oDAN",
    "rpYi0umkjiZajmLXeJqNKACR9e9o4sAULcMfAWoI",
    "g2ZO7er4gyXO1xLocMRWMC1OoGldV6ca3rVcYD3v",
    "mQXOJVfaQyojasJC0xA83zgayGuVITCsUhPMQsTJ",
    "tiqjYQwVPRTcY9qAIya2ZEDeSlEKT1Vvp1loCxtO",
    "WTWFQEGMB6TSB31YREWDurE5MjYNWjcDl9tstaFU",
    "VMai5PoN25wqLZQR8gsQYrjv25xttmTaWZNuKHUt",
    "s7uJQL82TefICGIEYdvbXe8H4v9B3v7L4cHQnwc9",
    "H669KIERrhFIQhm09WjDVqFYaxkNY9griPwpxQi0",
    "uCsiF9JQmHLeAyCKHygHhWrXjWnHvaW9zu7eDW2E",
    "KhHHf1h6U9EYFFxSFNRhSE7S97jGNCrIf4XsIwXc",
    "M0OhfkgLtFmHxkJAt3d2wKGxBqKzbI1GdIaJrDuM",
    "XM2kIM6piHA8yrZC94AeNbTSoQ7L1h620eFisXmz",
    "cueJ7rsH6PjlgZEWS54Fs9zQaxOSOPG4xHziGErw",
    "GGLRz2RkatRFfShviUq9FWj45n2rdMeE6EWIAHEt",
    "vnomPw6gTOSNJZmVsbM22K6YwslGZYxfF4L40Vo7",
    "yseME1YDpnih8X2K2tBLotg5vqi0giUbtELmg6d1",
    "xjkKdbMyQplauByLkUgZFK7R8IojLaMGFKfiONtU",
    "qIsvezpgrmB0okpDREGVTWY1rCG2B9Rm9pWWnyKA",
    "uwK3s1T2b2n42Gt2h4ig1vNY8hiAOR2zJgdCNYcT",
    "NMRRd3sIgRDMTrYXLrHheEgaHBoTosJFSS7ulv53",
    "xNwspMjcsUs5uWIIA5Nj7qg9gdenmHeN5bvNhxfQ",
    "aU887o8d4Z9s8mX7cNdo9WtCnQqDQcDxVWFHL7l8",
    "8WUPLbxriRbZ9nyqDy7Jj5m4EqdU9al6TlEyfyS2",
    "XBA2FXeDzbR38VJXWZ9NYniogyqnEj58y4bk49IJ",
    "uMFk8w1WC7cwvR2VCEuRquBtjuByJnse1eRiVgAS",
    "hpfW8DimDsQ8FVH1dEVBh8gNKSmvNCXKlJWqgIs3",
    "pHdSTpNQzGZaqCwQAdehIJKUx99wtYfrXpD7m6xV",
    "2tZIqFbIRf0XQPdRaepVJTUTXYouvRP9jF9xPNwP",
    "dgF8hwLIUNsDZKZtNaulxukDXdppPVqi8nxcFSls",
    "BqJV4dSTA6yC9g2xy5ua8hRKnDmrIhvSfGix2Izi",
    "BszCqIv18k1oKIwaCDvRLDle6iTxwmQT1vxyHxWr",
    "kLgG61RwJLZzctp4dIgRYTcKjUPTVsDp8cx630Qr",
    "dV2ZCVJmP069A5M53QyXFL1V7UUjdbPZPasFsHeV",
    "rlBO4Ydh7lSC6fvbcgCEwmfixbryp4RCt5O6WURa",
    "BoKxkwkOMgPH0Jiyz7a4lvavoV4xnjuw56HxVBXF",
    "ebGEs7Hg1NRjw3MkxTmuaV1RU0ly78iIABFru53B",
    "zBwUwVmIvbGWRci3xVgVQih2BUwKU7qD86zWFXm4",
    "eWLqllJpHL36hWYjHKZMuGKL9fNDn8d59jJya4y7",
    "eG32tj8e7jH2SZfVqzlpSPTe7fofRMzncNOOLXgA",
    "l3gu6CCfBAJwTuzdz22WEMeR6JXJ8besUqi5J7Wu",
    "bERJx5irm67TcQtWlh3flgY1Lu6WjnB4ZJffGu1u",
    "2QkVkXuTiOVqOIsHUUUSulcGNVBvcPj1fT7Dvy3U",
    "9jfsTxd3D9IiFAJTAgsGXUz9JGaIMBKBj7eGg9l9",
    "JSHl3VFehfBKpGcajoCQMHJZCcKo9itRNVwOoYJe",
    "OHpiIwSE8BvEgccvhcL53C4AorAiQawcD31maScF",
    "NronKhXJoVswjdwjzj5OC8c1YeAc4WSTraAOHi0w",
    "vzEb3tr2YnWscqJ4bPb8eBfNZYJEL45LI5Srd2tl",
    "4ukhtXK9V6M3XCLGA2NwFGKqqWkSynZENsDYh71s",
    "xfN0NnCcEnoqSFfsPlqSJm3gcKwaeqrffsRDW5qE",
    "bCRohATosJfuhqhNPQtL4UeMRtYcHr7jwONzo7ey",
    "scPzXrr10fEktG7EXjX3qP5TRx8XCBAliep8Prpy",
    "XgO1u0UIFsiJxKs64Zzs1TWN1RSEXGFpyqS4TlZg",
    "MnsqhqYXGj497Qil6QERwclKAStD4KtPY2YiZq4U",
    "WShswLao4QPoM09Hv9BFCiFugINaI5eBFEyx7nUV",
    "4ZH1vwsVQnUlAMC08D3BcN23EYCLwVXtFyI8HyUN",
    "lnRaDCaPDiurBpx3EelezmiyNGJRM6UsnRqp0LAN",
    "OAfg9LNBEubOqmbt33kqcmtPNZ0qjie3VSNoAf8p",
    "XGcWBpt2VpM1CkyngYwmibtxcdX0kC11Moe9XGhr",
    "V4nc7s4m3oazEhA11hN6FGKCjbNAkfbj1Wu4ToWU",
    "czukHUTxEeAFuxbWfNIA1BQjrYmnrQyxd9uiML5E",
    "93avU1F8VsSBOuAz5L21Bs5Xl2XAWI99Q7ZJu7yR",
    "aFcU3Hb1byIj2XyUZpmhSYPv6CVOwskOKnSdywBX",
    "FPTtwUAVrZbd1vlbJaR1Lj9tjSI2WLjjb0ioWvV4",
    "PCkZofhQkOyLFu22gWrIkqiqDVNEa5xySfJ7h4gk",
    "ULbnX7LMP6YQ1YxuX2WrXfrjyPgLxlX0eUsXVFJg",
    "Q8TMHUgl8fpMVFrROsHd6PO3tL4La9wwUa0MyBvI",
    "swHBUmaaGKKweRobaFShct6UkLNLfVgkTqIihujE",
    "Xdlschj80KWe59aP46x9aFuQJA7ViXHVdEakoYw4",
    "rEtuH5NzZHL0t4L6vJURx8HBlai8qP1ih0kLNp6e",
    "6FarWj3kQRLwF7dhGPxtP6TGp4YsQxbtOrpYBix3",
    "07o1GgHKjF3Hb8lTsMmnX1yoHTOLh9BvihYSgE60",
    "T7mHtla15MD3diXG4nhk2jWDCnZl0h4xMlVFWDOT",
    "hTE6U0mOxC3aUKvTwf3wbQV4Au0QnYIJtJ9SDYUw",
    "MwJtPdTajFdhiiMAengB966ixG8RxlTIaihyi1Li",
    "vEHgD2EYb8pXqGrwgYjkbimmcSbW0ARvn2YKuiCI",
    "WrjMYGW7gVObVltphiXcHocwi8a41qdZZE2XfPMF",
    "0DRR93N7jteVCdIVNoHBnZ4P6bMq6xmovZak8gEv",
    "WRiOmbNXwOSe2UZLzSWl9nlJojKggZzbN16Xzkn4",
    "SCXyh8tndM1kVJvSCvri2DPAea1V8Wd4ajXRZ2WU",
    "nSGqBevyM8UEkJwcIfGP7AOZ058YaBxIZmsGsWpN",
    "xxJuhfg32hIWQZNZJODgI3Lb3BOD7EIYGbUfMLZf"
};

var rand = new Random();
var strings = rawStrings
    .Select(str => str[..^(rand.Next() % 40 + 1)])
    .ToList();
    
Sleepsort(strings);

Console.WriteLine("================================================");

Console.WriteLine(string.Join("\n", SleepsortLinkedList(strings)));