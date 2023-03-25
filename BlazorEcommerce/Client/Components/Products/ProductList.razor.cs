namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductList
{
    private static List<Product> Products = new List<Product>()
    {
        new Product
        {
            Id = 1,
            Description = "Don Quixote[a][b] is a Spanish epic novel by Miguel de Cervantes. Originally published in two parts, in 1605 and 1615, its full title is The Ingenious Gentleman Don Quixote of La Mancha or, in Spanish, El ingenioso hidalgo don Quixote[b] de la Mancha (changing in Part 2 to El ingenioso caballero don Quixote[b] de la Mancha).[c] A founding work of Western literature, it is often labelled as the first modern novel[2][3] and one of the greatest works ever written.[4][5] Don Quixote is also one of the most-translated books in the world[6] and the best-selling novel of all time.",
            Title = "Don Quixote",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
            Price =149.99m
        },
        new Product
        {
            Id = 2,
            Description = "A Tale of Two Cities is a historical novel published in 1859 by Charles Dickens, set in London and Paris before and during the French Revolution. The novel tells the story of the French Doctor Manette, his 18-year-long imprisonment in the Bastille in Paris, and his release to live in London with his daughter Lucie whom he had never met. The story is set against the conditions that led up to the French Revolution and the Reign of Terror. In the Introduction to the Encyclopedia of Adventure Fiction, critic Don D'Ammassa argues that it is an adventure novel because the protagonists are in constant danger of being imprisoned or killed.[2]",
            Title = "A Tale of Two Cities",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
            Price =99.99m
        },
        new Product
        {
            Id = 3,
            Description = "The Little Prince (French: Le Petit Prince, pronounced [lə p(ə)ti pʁɛ̃s]) is a novella written and illustrated by French aristocrat, writer, and military pilot Antoine de Saint-Exupéry. It was first published in English and French in the United States by Reynal & Hitchcock in April 1943 and was published posthumously in France following liberation; Saint-Exupéry's works had been banned by the Vichy Regime. The story follows a young prince who visits various planets in space, including Earth, and addresses themes of loneliness, friendship, love, and loss. Despite its style as a children's book, The Little Prince makes observations about life, adults, and human nature.[9]",
            Title = "The Little Prince",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
            Price =149.99m
        },
        new Product
        {
            Id = 4,
            Description = "Harry Potter and the Philosopher's Stone is a 1997 fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry. Harry makes close friends and a few enemies during his first year at the school and with the help of his friends, Ron Weasley and Hermione Granger, he faces an attempted comeback by the dark wizard Lord Voldemort, who killed Harry's parents, but failed to kill Harry when he was just 15 months old.",
            Title = "Harry Potter and the Philosopher's Stone\r\n",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
            Price =149.99m
        },
        new Product
        {
            Id = 5,
            Description = "One Hundred Years of Solitude (Spanish: Cien años de soledad, American Spanish: [sjen ˈaɲoz ðe soleˈðað]) is a 1967 novel by Colombian author Gabriel García Márquez that tells the multi-generational story of the Buendía family, whose patriarch, José Arcadio Buendía, founded the fictitious town of Macondo. The novel is often cited as one of the supreme achievements in world literature.[1][2][3][4]\r\n\r\nThe magical realist style and thematic substance of One Hundred Years of Solitude established it as an important representative novel of the literary Latin American Boom of the 1960s and 1970s,[5] which was stylistically influenced by Modernism (European and North American) and the Cuban Vanguardia (Avant-Garde) literary movement.",
            Title = "One Hundred Years of Solitude\r\n",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
            Price =149.99m
        },
    };
}
