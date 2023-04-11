using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Data.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Description = "Don Quixote[a][b] is a Spanish epic novel by Miguel de Cervantes. Originally published in two parts, in 1605 and 1615, its full title is The Ingenious Gentleman Don Quixote of La Mancha or, in Spanish, El ingenioso hidalgo don Quixote[b] de la Mancha (changing in Part 2 to El ingenioso caballero don Quixote[b] de la Mancha).[c] A founding work of Western literature, it is often labelled as the first modern novel[2][3] and one of the greatest works ever written.[4][5] Don Quixote is also one of the most-translated books in the world[6] and the best-selling novel of all time.",
                    Title = "Don Quixote",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
                    Price = 149.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Description = "A Tale of Two Cities is a historical novel published in 1859 by Charles Dickens, set in London and Paris before and during the French Revolution. The novel tells the story of the French Doctor Manette, his 18-year-long imprisonment in the Bastille in Paris, and his release to live in London with his daughter Lucie whom he had never met. The story is set against the conditions that led up to the French Revolution and the Reign of Terror. In the Introduction to the Encyclopedia of Adventure Fiction, critic Don D'Ammassa argues that it is an adventure novel because the protagonists are in constant danger of being imprisoned or killed.[2]",
                    Title = "A Tale of Two Cities",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
                    Price = 99.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Description = "The Little Prince (French: Le Petit Prince, pronounced [lə p(ə)ti pʁɛ̃s]) is a novella written and illustrated by French aristocrat, writer, and military pilot Antoine de Saint-Exupéry. It was first published in English and French in the United States by Reynal & Hitchcock in April 1943 and was published posthumously in France following liberation; Saint-Exupéry's works had been banned by the Vichy Regime. The story follows a young prince who visits various planets in space, including Earth, and addresses themes of loneliness, friendship, love, and loss. Despite its style as a children's book, The Little Prince makes observations about life, adults, and human nature.[9]",
                    Title = "The Little Prince",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
                    Price = 149.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Description = "Harry Potter and the Philosopher's Stone is a 1997 fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry. Harry makes close friends and a few enemies during his first year at the school and with the help of his friends, Ron Weasley and Hermione Granger, he faces an attempted comeback by the dark wizard Lord Voldemort, who killed Harry's parents, but failed to kill Harry when he was just 15 months old.",
                    Title = "Harry Potter and the Philosopher's Stone\r\n",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
                    Price = 149.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Description = "One Hundred Years of Solitude (Spanish: Cien años de soledad, American Spanish: [sjen ˈaɲoz ðe soleˈðað]) is a 1967 novel by Colombian author Gabriel García Márquez that tells the multi-generational story of the Buendía family, whose patriarch, José Arcadio Buendía, founded the fictitious town of Macondo. The novel is often cited as one of the supreme achievements in world literature.[1][2][3][4]\r\n\r\nThe magical realist style and thematic substance of One Hundred Years of Solitude established it as an important representative novel of the literary Latin American Boom of the 1960s and 1970s,[5] which was stylistically influenced by Modernism (European and North American) and the Cuban Vanguardia (Avant-Garde) literary movement.",
                    Title = "One Hundred Years of Solitude\r\n",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Polish_sci_fi_fantasy_books.JPG/170px-Polish_sci_fi_fantasy_books.JPG",
                    Price = 149.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 6,
                    Description = "Seven (stylized as Se7en)[1] is a 1995 American crime thriller film directed by David Fincher and written by Andrew Kevin Walker. It stars Brad Pitt, Morgan Freeman, Gwyneth Paltrow, and John C. McGinley. Set in a crime-ridden, unnamed city, Seven's plot follows disenchanted, near-retirement detective William Somerset (Freeman) and his new partner, the recently transferred David Mills (Pitt), as they attempt to stop a serial killer before he can complete a series of murders based on the seven deadly sins.",
                    Title = "Seven",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/68/Seven_%28movie%29_poster.jpg",
                    Price = 35.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Description = "Inception is a 2010 science fiction action film[4][5][6] written and directed by Christopher Nolan, who also produced the film with Emma Thomas, his wife. The film stars Leonardo DiCaprio as a professional thief who steals information by infiltrating the subconscious of his targets. He is offered a chance to have his criminal history erased as payment for the implantation of another person's idea into a target's subconscious.[7] The ensemble cast includes Ken Watanabe, Joseph Gordon-Levitt, Marion Cotillard, Elliot Page,[a] Tom Hardy, Dileep Rao, Cillian Murphy, Tom Berenger, and Michael Caine.",
                    Title = "Inception",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg",
                    Price = 35.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 8,
                    Description = "Grand Theft Auto: San Andreas is a 2004 action-adventure game developed by Rockstar North and published by Rockstar Games. It is the fifth main entry in the Grand Theft Auto series, following 2002's Grand Theft Auto: Vice City, and the seventh installment overall. It was released in October 2004 for the PlayStation 2, in June 2005 for Microsoft Windows and Xbox, and in November 2010 for Mac OS X.[2][3] The game is set within an open world environment that players can explore and interact with at their leisure. The story follows Carl \"CJ\" Johnson, who returns home following his mother's murder and is drawn back into his former gang and a life of crime while clashing with corrupt authorities and powerful criminals. Carl's journey takes him across the fictional U.S. state of San Andreas, which is based on California and Nevada and encompasses three major cities: Los Santos (inspired by Los Angeles), San Fierro (San Francisco) and Las Venturas (Las Vegas).",
                    Title = "Grand Theft Auto: San Andreas",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/c/c4/GTASABOX.jpg/220px-GTASABOX.jpg",
                    Price = 35.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    Description = "S.T.A.L.K.E.R.: Call of Pripyat is a first-person shooter survival horror video game developed by GSC Game World for Microsoft Windows. It is the third game released in the S.T.A.L.K.E.R. series of video games, following S.T.A.L.K.E.R.: Shadow of Chernobyl and S.T.A.L.K.E.R.: Clear Sky, with the game's narrative and events following the former. It was published in the CIS territories by GSC World Publishing in October 2009, before being released by Deep Silver and bitComposer Games in North America and the PAL region in February 2010.",
                    Title = "S.T.A.L.K.E.R.: Call of Pripyat",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9a/Stalker_Call_of_Pripyat_cover.jpg/220px-Stalker_Call_of_Pripyat_cover.jpg",
                    Price = 35.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 10,
                    Description = "\"Hello\" is a song recorded by English singer-songwriter Adele, released on 23 October 2015 by XL Recordings as the lead single from her third studio album, 25 (2015). Written by Adele and with its producer, Greg Kurstin, \"Hello\" is a piano ballad with soul influences (including guitar and drums), and lyrics that discuss themes of nostalgia and regret. Upon release, the song garnered critical acclaim, with reviewers comparing it favourably to Adele's previous works and praised its lyrics, production and Adele's vocal performance. It was recorded in Metropolis Studios, London.",
                    Title = "Hello",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/85/Adele_-_Hello_%28Official_Single_Cover%29.png/220px-Adele_-_Hello_%28Official_Single_Cover%29.png",
                    Price = 35.99m,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 11,
                    Description = "\"Ohne dich\" (German pronunciation: [ˈoːnə ˌdɪç] \"Without You\") is a song by German Neue Deutsche Härte band Rammstein. It was released on 22 November 2004 as the third single from their fourth studio album, Reise, Reise (2004).",
                    Title = "Ohne dich",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/2/26/Ohnedichsingle.jpg/220px-Ohnedichsingle.jpg",
                    Price = 35.99m,
                    CategoryId = 4
                });
        }
    }
}