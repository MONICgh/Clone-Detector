using CollectionSort;

var peopleList = new List<Person>
{
    new ("Garrick Bigwood", 17),
    new ("John Black", 8),
    new ("David Blundell", 29),
    new ("Peter Brown", 11),
    new ("Paul Buchanan", 13),
    new ("Christopher Burnett", 45),
    new ("Malcolm Carter", 66),
    new ("Michael Chelton", 1),
    new ("Ian Chew", 56),
    new ("Paul Clements", 23),
    new ("Verka Cole", 64),
    new ("Martin Cox", 83),
    new ("Phillip Dickinson", 23),
    new ("Karl Dobson", 54),
    new ("Michael Dunne", 43),
    new ("Gertrude Finney", 32),
    new ("Jacqueline Fisher", 21),
    new ("Patrick Gallagher", 10),
    new ("John Galloway", 86),
    new ("Andrew Gillett", 92),
    new ("Gary Haines", 66),
    new ("Daniel Hayes", 78),
    new ("Thelma Johnson", 73),
    new ("Bernard Kelly", 3),
    new ("Thomas Lindsay", 5),
    new ("Robert Maker", 1),
    new ("Laveina McCullagh", 4),
    new ("Vincent McKinnon", 6),
    new ("Rachna Mishra", 7),
    new ("Peter Mueller", 9),
    new ("Kenneth Muller", 14),
    new ("Rebecca Needle", 14),
    new ("Russell Osman", 62),
    new ("Mathew Paige", 37),
    new ("Stephen Peak", 38),
    new ("Malcolm Phillips", 26),
    new ("Thomas Rees", 38),
    new ("Samuel Ruddle", 40),
    new ("Jeremy Shaw", 46),
    new ("Jacqueline Spencer", 48),
    new ("Thomas Stamp", 23),
    new ("Terri-Anne Thorpe", 22),
    new ("Michael Timothy", 21),
    new ("Frank Wakeling", 44),
    new ("Clive Ward", 35),
    new ("Robert Wilkinson", 38),
    new ("Gillian Williams", 12),
    new ("Sarah Wilson", 13),
    new ("Michael Wright", 97),
    new ("Michael Wright", 4)
};

peopleList.Sort(new NameComparator());
foreach (var person in peopleList)
{
    Console.WriteLine(person);
}

Console.WriteLine("==================================");

peopleList.Sort(new AgeComparator());
foreach (var person in peopleList)
{
    Console.WriteLine(person);
}