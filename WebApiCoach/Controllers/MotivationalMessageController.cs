using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiCoach.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivationalMessageController : Controller
    {
        private static readonly string[] Messages = new[]
        {
            "“A arte de ser ora audacioso, ora prudente, é a arte de vencer.” – Napoleão Bonaparte",
            "“Nossos fracassos, às vezes, são mais frutíferos do que os êxitos.” – Henry Ford",
            "“Comemore os seus sucessos. Veja com humor os seus fracassos.” – Sam Walton",
            "“Não somos responsáveis apenas pelo que fazemos, mas também pelo que deixamos de fazer.” – Moliere",
            "“É costume de um tolo, quando erra, queixar-se dos outros. É costume de um sábio queixar-se de si mesmo.” – Sócrates",
            "“Existe o risco que você jamais pode correr. Existe o risco que você jamais pode deixar de correr.” – Peter Drucker",
            "“Mesmo que já tenhas feito uma longa caminhada, há sempre um novo caminho a fazer.” – Santo Agostinho",
            "“A felicidade não está em fazer o que a gente quer, e sim querer o que a gente faz.” – Jean Paul Sartre",
            "“É sempre divertido fazer o impossível.” – Walt Disney",
            "“Experiência é o nome que cada um dá a seus erros.” – Oscar Wilde",
            "“Somente os que ousam errar muito podem realizar muito.” – John F. Kennedy",
            "“Somos o que repetidamente fazemos. Portanto, a excelência não é um feito, é um hábito.” – Aristóteles",
            "“Toda empresa precisa ter gente que erra, que não tem medo de errar e que aprende com erro.” – Bill Gates",
            "“A confiança em si mesmo é o primeiro segredo do sucesso.” – Ralph Waldo Emerson",
            "“Aquele que pretende ser um líder tem que ser uma ponte.” – Provérbio Galês",
            "“Muda tuas ideias e mudarás teu mundo.” – Norman Vincent Peale",
            "“A vitória sempre foi de quem nunca duvidou dela.” – Raul Follerean",
            "“Se existe uma forma de fazer melhor, descubra-a.” – Thomas Edison",
            "“O problema é que a maioria das pessoas prefere um elogio que prejudique do que uma crítica que beneficie.” – Norman Vincent Peale",
            "“A sorte favorece a mente preparada.” – Louis Pasteur",
            "“Não há sucesso sem dificuldade.” – Sófocles",
            "“A maior recompensa pelo trabalho não é o que a pessoa ganha, é o que ela se torna através dele.” – John Ruskin",
            "“Não encontre defeitos, encontre soluções. Qualquer um sabe queixar-se.” – Henry Ford",
            "“Conhecimento não é aquilo que você sabe, mas o que você faz com aquilo que sabe.” – Aldous Huxley",
            "“Critica o que fazes, e não faças o que criticas.” – Provérbio Árabe",
            "“Se sonhar grande dá o mesmo trabalho que sonhar pequeno, por que vou sonhar pequeno?.” – Jorge Paulo Lemann",
            "“Por vezes sentimos que aquilo que fazemos não é senão uma gota de água no mar. Mas o mar seria menor se lhe faltasse uma gota.” – Madre Teresa de Calcutá",
            "“Destino não é exterior a nós; somos nós que criamos nosso próprio destino dia após dia.” – Henry Miller",
            "“Ontem foi ontem, já passou. Hoje é hoje e é o que nos importa. Amanhã, o futuro, a Deus pertence.” – Samuel Klein",
            "“Você precisa fazer aquilo que pensa que não é capaz de fazer.” – Eleanor Roosevelt",
            "“Faça o que puder, com o que tiver, onde estiver.” – Theodore Roosevelt",
            "“A vida é curta demais. Não corra o risco de passar seus dias apenas afinando seu instrumento sem jamais fazer um grande espetáculo.” – Carlos Wizard Martins",
            "“Tudo que você precisa fazer é mover as pessoas só um pouquinho para mudanças acontecerem. Não precisa ser algo enorme.” – Viola Davis",
            "“Nossas dúvidas são traidoras e nos fazem perder, por medo de tentar, o que poderíamos ganhar.” – William Shakespeare",
            "“Se você quer fazer uma coisa realmente grande, seja grande como a coisa que você quer fazer.” – Nizan Guanaes",
            "“Aquele que é feliz, espalha felicidade. Aquele que teima na infelicidade, que perde o equilíbrio e a confiança, perde-se na vida.” – Anne Frank",
            "“Os problemas são apenas oportunidades com roupas de trabalho.” – Henry John Kaiser",
            "“Na crise, existem aqueles que se abatem, sentam no chão e choram; e existem aqueles que fabricam e vendem lenços. Nós somos fabricantes de lenços.” – Abilio Diniz",
            "“Levanto a minha voz, não para que eu possa gritar, mas para que aqueles sem voz possam ser ouvidos….” – Malala Yousafzai",
            "“Em todas as situações, deve-se considerar o objetivo.” – Jean de La Fontaine",
            "“Se você quer saber o quanto você é forte, é na necessidade que descobrimos que somos gigantes.” – Cleusa Maria da Silva",
            "“Só se aprende com a experiência. Portanto, não importa o que as pessoas lhe digam, você tem que viver e cometer seus próprios erros para aprender.” – Emma Watson",
            "“É o motivo que engrandece a ação; é o fazer, não o feito.” – Margaret Preston",
            "“Um grande líder é exemplo pela atitude, não pelo discurso.” – Robinson Shiba",
            "“Sucesso é mais frequentemente alcançado por aqueles que não sabem que o fracasso é inevitável.” – Coco Chanel",
            "“Quem vive sem disciplina morre sem honra.” – Provérbio islandês",
            "“Um dia é preciso parar de sonhar, tirar os planos da gaveta e, de algum modo, começar.” – Amyr Klink",
            "“A maior descoberta de todos os tempos é que uma pessoa pode mudar, simplesmente mudando de atitude.” – Oprah Winfrey",
            "“Mesmo se você estiver no caminho certo será atropelado se ficar sentado nele.” – Will Rogers",
            "“O fundamental é manter sempre a mesma obsessão em alcançar o sucesso. Ter sucesso não é apenas ter dinheiro, mas sim saber que uma ideia que parece impossível pode vir a ser uma empresa que irá quebrar paradigmas.” – Romero Rodrigues",
            "“O jeito mais eficiente de fazer algo é fazendo.” – Amelia Earhart",
            "“O insucesso é uma oportunidade para recomeçar com mais inteligência.” – Henry Ford",
            "“O liderado será reflexo da sua liderança, então quem espera lealdade, primeiro deve ser leal.” – Flávio Augusto",
            "“Sozinhos, pouco podemos fazer; juntos, podemos fazer muito.” – Helen Keller",
            "“Uma atitude vitoriosa é meio caminho andado para o sucesso.” – Arthur Riedel",
            "“Quando diz ‘estou cada vez melhor’, você erotiza, ilumina com amor, um olhar, um pensamento, e suas circunstâncias. Você vence a sombra. Assim, convocando a beleza, vence a tendência à banalização da vida, que por vezes predomina à nossa volta.” – Antônio Luiz Seabra",
            "“Lembre-se que não conseguir o que você quer é algumas vezes um lance de sorte.” – Dalai Lama",
            "“E o problema é que, se você não arrisca nada, você arrisca mais.” – Erica Jong",
            "“Nada é mais desafiador do que superar uma situação não planejada.” – Nelson Sirotsky",
            "“Perde tudo quem perde o momento certo.” – Provérbio espanhol",
            "“A fórmula da felicidade e do sucesso é simplesmente ser você mesmo da maneira mais sincera que puder.” – Meryl Streep",
            "“Eu não tenho Ídolos. Tenho admiração por trabalho, dedicação e competência.” – Ayrton Senna",
            "“Você nunca pode atravessar o oceano até que você tenha coragem de perder de vista a costa.” – Cristóvão Colombo",
            "“O segredo do nosso sucesso é que nós nunca, nunca desistimos.” – Wilma Mankiller",
            "“ Não importa o quão rápido você anda, mas a força de vontade para nunca parar.” – Confúcio",
            "“Não perca tempo tentando mudar a opinião dos outros. Faça seu trabalho e não ligue para o que pensam.” – Tina Fey",
            "“ Você não pode deixar de usar a criatividade. Quanto mais você usa, mais você tem.” – Maya Angelou",
            "“Há apenas uma maneira de evitar críticas: não fazer, não falar e não ser nada .” Aristóteles",
            "“Sonhos são adoráveis. Mas são só sonhos. São fugazes, efêmeros, bonitos. Sonhos não se tornarão realidade só porque você sonhou. É o esforço que faz as coisas acontecerem. É o esforço que cria mudança.” – Shonda Rhimes",
            "“Ter problemas na vida é inevitável. Ser derrotado por eles é opcional.” – Roger Crowford",
            "“Seu tempo é limitado, então não perca tempo vivendo a vida de outra pessoa.” – Steve Jobs",
            "“Mude a sua vida hoje. Não deixe para arriscar no futuro, aja agora, sem atrasos.” – Simone de Beauvoir",
            "“É importante aprender a não se aborrecer com opiniões diferentes das suas.” – Bertrand Russell",
            "“Na adversidade, uns desistem, enquanto outros batem recordes.” – Ayrton Senna",
            "“Espíritos grandiosos sempre encontraram oposição violenta de mentes medíocres.” – Albert Einstein",
            "“Quando você tropeçar, mantenha a fé. Quando for nocauteado, levante rápido. Não ouça quem diz que você não pode ou não deve continuar.” – Hillary Clinton",
            "“A distância entre o sonho e a realidade, chama-se disciplina.” – Bernardinho",
            "“Mestre não é quem sempre ensina, mas quem de repente aprende.” – João Guimarães Rosa",
            "“Se fizemos um planejamento e estabelecemos metas, o resultado tem de aparecer. Eu não gosto de bengalas, que é como eu chamo quando a pessoa chega e vai apresentando uma desculpa. Traga o problema e também uma solução.” – Sonia Hess",
            "“O mundo está na mão daqueles que têm a coragem de sonhar e de correr o risco de viver seus sonhos.” – Paulo Coelho",
            "“Tenho aprendido ao longo dos anos que, quando a mente está pronta, isso diminui o medo.” – Rosa Parks",
            "“Você falha, e aí? A vida continua. É só quando você se arrisca a falhar que descobre coisas.” – Lupita Nyong’o",
            "“No fim tudo dá certo, e se não deu certo é porque ainda não chegou ao fim.” – Fernando Sabino",
            "“O mais corajoso dos atos ainda é pensar com a própria cabeça.” – Coco Chanel",
            "“Alguns fracassos são inevitáveis. É impossível viver sem fracassar em alguma coisa, a não ser que você viva tomando tanto cuidado com tudo que você simplesmente não viva.” – J. K. Rowling",
            "“As invenções são o resultado de um trabalho teimoso.” – Santos Dumont",
            "“Nada contribui tanto para clarear a mente do que um objetivo claro.” – Marry W. Shelley",
            "“Às vezes a gente tem de ser meio louco mesmo, extremamente obstinado, porque a loucura funciona – desde que exista disciplina, um objetivo muito claro, pé no chão e a humildade de saber que a gente vai errar muito, vai aprender com os erros e continuar.” – Leila Velez",
            "“Não existe falta de tempo, existe falta de interesse. Porque quando a gente quer mesmo, a madrugada vira dia. Quarta-feira vira sábado e um momento vira oportunidade.” – Pedro Bial",
            "“Tudo o que você sempre quis está do outro lado do seu medo.” – George Addair",
            "“Você não crescerá a não ser que tente algo além daquilo que já domina.” – Ronald Osborn",
            "“Faça coisas. Seja curioso, persistente. Não espere por um empurrão da inspiração ou por um beijo da sociedade na sua testa. Preste atenção. É tudo sobre prestar atenção. É tudo sobre captar o máximo que você puder do que está por aí e não deixar que desculpas e que a monotonia de algumas obrigações diminuam sua vida.” – Susan Sontag",
            "“Você pode mudar sem crescer, mas não pode crescer sem mudar.” – Larry Wilson",
            "“Quanto mais velha eu fico, mais me interesso pelas mulheres. Ainda não conheci uma mulher que não é forte. Elas não existem.” – Diane von Furstenberg",
            "“Nossa paciência conquistará mais do que a nossa força.” – Edmund Burke",
            "“Respeite sua essência, seja você mesma, é o jeito mais inteligente de construir seu estilo, sua maneira de viver e de se vestir. E você vai ver: estilo é fundamental para a autoestima.” – Constanza Pascolato",
            "“Certifique-se de que suas palavras e seus atos estão em harmonia.” – Claus Moller",
            "“Descubra quem você é e seja essa pessoa. Isso é o que sua alma foi colocada nesta Terra para ser. Encontre essa verdade, viva essa verdade e tudo mais virá.” – Ellen Degeneres",
            "“Quanto maior a dificuldade maior é o mérito de superá-la.” – H. W. Beecher",            
            "“Não há saber mais ou saber menos: há saberes diferentes.” – Paulo Freire",
            "“Nunca é tarde demais para ser o que você poderia ter sido.” – George Eliot",
            "“Ao fim do dia, podemos aguentar muito mais do que pensamos que podemos.” – Frida Kahlo",
            "“Ouça qualquer um que tenha uma ideia original. Encoraje-o. Deixe as pessoas continuarem suas ideias.” – William McKnight",
            "“Esforce-se para não ser um sucesso, mas sim para ser valioso.”. Albert Einstein",
            "“Eu defino o poder pela confiança para tomar suas próprias decisões, para não ser influenciado por outras pessoas, e ser corajoso e destemido ao saber que, mesmo se você tomar a decisão errada, você fez isso por uma boa razão.” – Adele",
            "“Não ergas um edifício sem fortes alicerces ou viverás com medo.” – Sabedoria Persa",
            "“Você está aqui por uma razão, muitas vezes suas inseguranças e sua falta de experiência podem te levar a se apegar às expectativas ou valores de outras pessoas. Você pode aproveitar isso para esculpir seu caminho, livre da carga de saber como as coisas devem ser, definido por suas particularidades.” – Natalie Portman",
            "“Você nunca vai chegar ao seu destino se você parar e atirar pedras em cada cão que late.” – Winston Churchill",
            "“Assistir a grandes pessoas fazerem o que você ama é uma boa maneira de se inspirar.” – Amy Poehler",
            "“Uma pessoa que nunca cometeu um erro, nunca tentou nada de novo.”. Albert Einstein",
            "“Eu não sonhei com sucesso. Eu trabalhei para ele.” – Estée Lauder",
            "“Ganhar não é tudo, mas querer ganhar é.” – Vince Lombardi",
            "“Os meus maiores sucessos chegaram no seguimento de grandes fracassos.” – Barbara Corcoran",
            "“Sonhe grande e se atreva a falhar.” – Norman Vaughan",
            "“Não espere por grandes líderes; faça você mesmo, pessoa a pessoa. Seja leal às ações pequenas porque é nelas que está a sua força.” – Madre Teresa de Calcutá",
            "“Você pode ficar desapontado se falhar, mas já está derrotado se não tentar.”. Beverly Sills",
            "“Aprendi a aceitar desafios que nunca pensei fazer antes. Sucesso e conforto não podem coexistir.” – Ginni Rometty",
            "“Na vida sempre fazemos escolhas. Ainda que escolhemos não escolher.”. Carmen Miranda",
            "“Sempre fiz algo que eu achava que estava pouco preparada para fazer. Quando você tem um momento de incerteza mas persiste, é aí que você consegue avançar.” – Marissa Mayer",
            "“Quem sabe faz a hora, não espera acontecer.” – Geraldo Vandré",
            "“Defina sucesso com seus próprios termos, o alcance segundo as suas próprias regras e viva uma vida da qual você se orgulhe.” – Anne Sweeney",
            "“O sucesso nasce do querer, da determinação e persistência em se chegar a um objetivo. Mesmo não atingindo o alvo, quem busca e vence obstáculos, no mínimo fará coisas admiráveis” – José de Alencar",
            "“Se você quer ser bem-sucedido precisa de dedicação total, buscar seu último limite e dar o melhor de si mesmo” – Ayrton Senna",
            "“Não crie limites para si mesmo. Você deve ir tão longe quanto sua mente permitir. O que você mais quer pode ser conquistado” – Mary Kay Ash",
            "“Nenhum obstáculo será grande se a sua vontade de vencer for maior” – Autor desconhecido",
            "“Dificuldades preparam pessoas comuns para destinos extraordinários” C.S Lewis",
            "“Nenhum homem será um grande líder se quiser fazer tudo sozinho ou se quiser levar todo o crédito por fazer isso” – Andrew Carnegie",
            "“Bom mesmo é ir à luta com determinação, abraçar a vida com paixão, perder com classe e vencer com ousadia, porque o mundo pertence a quem se atreve e a vida é muito curta, para ser insignificante” — Charlie Chaplin",
            "“Pessoas vencedoras não são aquelas que não falham, são aquelas que não desistem”  – Autor desconhecido",
            "“Só existem dois dias do ano em que você não pode fazer nada: um se chama ontem e outro amanhã” – Dalai Lama",
            "“A vida é um constante recomeço. Não se dê por derrotado e siga adiante. As pedras que hoje atrapalham sua caminhada amanhã enfeitarão a sua estrada”  – Autor desconhecido",
            "“Ouse ir além, ouse fazer diferente e o poder lhe será dado!” – José Roberto Marques",
            "“Ouse, arrisque, não desista jamais e saiba valorizar quem te ama, esses sim merecem seu respeito. Quanto ao resto, bom, ninguém nunca precisou de restos para ser feliz” – Clarice Lispector",
            "“Para ser um campeão você tem que acreditar em si mesmo quando ninguém mais acredita” – Muhammad Ali",
            "“No fim tudo dá certo, e se não deu certo é porque ainda não chegou ao fim” – Fernando Sabino",
            "“Você nunca sabe que resultados virão da sua ação. Mas se você não fizer nada, não existirão resultados” – Mahatma Gandhi",
            "“O pessimista vê dificuldade em toda oportunidade. O otimista vê oportunidade em toda dificuldade” – Winston Churchill",
            "“A paciência é um elemento fundamental do sucesso” – Bill Gates",
            "“Reclamar não é uma estratégia. É necessário lidarmos com o mundo como ele é e não como gostaríamos que ele fosse” – Jeff Bezos. ",
            "“O sucesso não tem a ver com o lugar de onde você veio, e sim com a confiança que você tem e o esforço que você está disposto a investir” – Michelle Obama",
            "“Você pode encarar um erro como uma besteira a ser esquecida, ou como um resultado que aponta uma nova direção” – Steve Jobs",
            "“Você não pode ser uma pessoa difícil, tímida, que não é capaz de olhar alguém nos olhos; você tem que se apresentar. Você tem que saber como falar sobre si mesmo, sua visão, o seu foco e em que você acredita” – Anna Wintour",
            "“Eu posso aceitar a falha, todos falham em alguma coisa. Mas eu não posso aceitar não tentar” – Michael Jordan",
            "“Gostaria que você soubesse que existe dentro de si uma força capaz de mudar sua vida. Basta que lute e aguarde um novo amanhecer” – Margaret Thatcher",
            "“Inteligência é a capacidade de se adaptar às mudanças” – Stephen Hawking",
        };

        private readonly ILogger<MotivationalMessageController> _logger;

        public MotivationalMessageController(ILogger<MotivationalMessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MotivationalMessage> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new MotivationalMessage
            {
                Message = Messages[rng.Next(Messages.Length)]
            })
            .ToArray();
        }
    }
}
