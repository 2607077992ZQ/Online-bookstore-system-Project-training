create database MyBookShop
go

use MyBookShop
go

create table UserRoles
(
Id int primary key identity(1,1),
Name nvarchar(200) not null
)
go

create table UserStates
(
Id int primary key identity(1,1),
Name nvarchar(200) not null
)
go

create table Users
(
Id int primary key identity(1,1),
LoginId nvarchar(50) not null,
LoginPwd nvarchar(50) not null,
Name nvarchar(50),
[Address] nvarchar(200),
Phone nvarchar(100),
Mail nvarchar(100),
UserRoleId int references UserRoles(Id),
UserStateId int references UserStates(Id)
)
go

create table Categories
(
Id int primary key identity(1,1),
Name nvarchar(200) not null
)
go

create table Publishers
(
Id int primary key identity(1,1),
Name nvarchar(200) not null
)
go

create table Orders
(
Id int primary key identity(1,1),
OrderDate datetime not null,
UserId int references Users(Id),
TotalPrice decimal(10,2) not null
)
go

create table Books
(
Id int primary key identity(1,1),
Title nvarchar(200) not null,
Author nvarchar(200) not null,
PublisherId int references Publishers(Id),
ISBN nvarchar(50) not null,
WordsCount int not null,
Unitprice money not null,
ContentDescription varchar(max),
AuthorDescription varchar(max),
EditorComment varchar(max),
CategoryId int references Categories(Id),
Clicks int not null
)
go

create table OrderBook
(
Id int primary key identity(1,1),
OrderID int references Orders(Id),
BookID int references Books(Id),
Quantity int not null,
UnitPrice decimal(18,2) not null
)
go

create view ShopCart
as
select
Orders.Id'oid' ,users.Id'uId',Books.Id'bookId',Books.Title'title',Books.ISBN'ISBN',OrderBook.Quantity'Quantity',OrderBook.UnitPrice'UnitPrice',Orders.TotalPrice'TotalPrice'
from Books,OrderBook,Orders,Users
where Books.Id=OrderBook.BookID and OrderBook.OrderID=Orders.Id and Orders.UserId=Users.Id
go

create view ShowInfo
as
select Books.Id 'BId',Books.ISBN 'ISBN' , Title 'title',Publishers.Name 'PublisherId',Books.AuthorDescription 'AuthorDescription',Books.ContentDescription 'ContentDescription' ,Books.Unitprice 'Unitprice'  from Books,Categories,Publishers 
where Publishers.Id=Books.PublisherId and Books.CategoryId=Categories.Id
go

insert into UserRoles values('普通用户')
insert into UserRoles values('管理员')
insert into UserRoles values('VIP用户')

insert into UserStates values('正常')
insert into UserStates values('无效')

insert into Categories values('小说');
insert into Categories values('历史');
insert into Categories values('科学技术');
insert into Categories values('开发类');
go

insert into Publishers values('湖南文艺出版社');
insert into Publishers values('湖南人民出版社');
insert into Publishers values('首都师范大学出版社');
insert into Publishers values('中华书局');
insert into Publishers values('清华大学出版社');
insert into Publishers values('百花洲文艺出版社');
insert into Publishers values('人民邮电出版社');
go

insert into Books values('从你的全世界路过','张嘉佳','1','9787540466893','270000','64.6','《从你的全世界路过》是青年作家张嘉佳的一部小说集，在原版的基础上，新增了9个打动人心的故事。新加入的故事之中，有讲述亲人死生契阔的悲伤无奈，有讲述年少友谊的纯真如梦，也有初恋的辛酸甜美和爱恨交加。故事里有悲伤，却不乏希望。这些故事，仿佛都曾经发生在我们的周围，有感动，有治愈，有笑中带泪，也有感伤中的温暖，张嘉佳以幽默而不失真诚的笔触，让人感受到心灵的触动与震撼。','张嘉佳 作家 毕业于南京大学，出版作品：《从你的全世界路过》《让我留在你身边》《几乎成了英雄》《情人书》','','1','');
insert into Books values('让我留在你身边','张嘉佳','1','9787543899179','87000','38','2013年年末，《从你的全世界路过》温暖上市，张嘉佳成为用睡前故事打动千万人的失眠者。《让我留在你身边》是她另一个作品。','张嘉佳 作家 毕业于南京大学，出版作品：《从你的全世界路过》《让我留在你身边》《几乎成了英雄》《情人书》','','1','');
insert into Books values('云边有个小卖部','张嘉佳','1','9787540487645','215000','42','让刘十三陪着你，走进云边镇的春夏秋冬，见证每一场相遇与离别。“有些人刻骨铭心，没几年会遗忘。有些人不论生死，都陪在身旁。”','张嘉佳 作家 毕业于南京大学，出版作品：《从你的全世界路过》《让我留在你身边》《几乎成了英雄》《情人书》','','1','')
insert into Books values('天堂旅行团','张嘉佳','1','9787572602825','81000','48','生命的终章，我踏上了一段旅途。开着破烂的面包车，穿越几十座城市，撕开雨天，潜入他乡，尽头是天堂。浅蓝的天光，泛紫的云层，路灯嵌进夕阳。山间道路弥漫着一万吨水汽，密林卷来风声，我闯进无止境的夜里。她说，天总会亮的。那么，我们一起记录下，凌晨前的人生。','张嘉佳 作家 毕业于南京大学，出版作品：《从你的全世界路过》《让我留在你身边》《几乎成了英雄》《情人书》','','1','')
insert into Books values('罪与罚','(俄)陀思妥耶夫斯基著','3','9787565632891','489000','59','小说以主人公拉斯科利尼科夫犯罪时及犯 罪后受到良心和道德惩罚为主线，广泛地描写了俄国 城市贫民走投无路的悲惨境遇和日趋尖锐的社会矛盾 。作者怀着真切的同情和满腔的激愤，将19世纪60年 代沙俄京城的黑暗、赤贫、*望和污浊全部无情地展 现在读者面前。','费奥多尔·米哈伊洛维奇·陀思妥耶夫斯基，十九世纪群星灿烂的俄国文坛上一颗耀眼的明星，与列夫·托尔斯泰、屠格涅夫等人齐名，是俄国文学的卓越代表。','','1','')
insert into Books values('鹿苑长春','(美)金·罗琳斯著','3','9787565632518','305000','48','《鹿苑长春》通过小主人公裘弟和他的小鹿的故事，生动地描写了美国南北战争后佛罗里达州垦荒区普通人的劳动、斗争和悲欢离合。作品充满浓郁的乡土气息，迷人的自然风景描写赢得了广泛的赞誉。','金·罗琳斯（1896-1953），美国作家，生于华盛顿，毕业于威斯康星大学。','','1','')
insert into Books values('言叶之庭','新海诚','6','9787550012295','124000','38','新海诚原作的《言叶之庭》讲述了：高中生秋月孝雄梦想着成为制鞋师，总是在下雨天的上午溜到公园的庭院里绘制鞋子的设计草图。有一天，孝雄在庭院里遇到了白领雪野百香里，她一边吃巧克力一边饮啤酒的样子引起了孝雄的注意。之后的日子里，两人不约而同，总是在下雨天碰面。在梅雨季节里，两个孤独的陌生人却渐渐向彼此靠拢，给予对方鼓励和温暖。当雪野在人生道路上感到迷惘时，孝雄决定替她做一双鞋子，希望她能够靠自己的双脚找到方向并坚定地走下去。梅雨季节即将结束，生活归于美好的平静。','新海诚：著名动画导演，被誉为日本新锐动画大师。2002年，凭借几乎独自完成的短篇动画《星之声》赢得人气，之后相继发表了《云之彼岸，约定的地方》《秒速五厘米》《追逐繁星的孩子》《言叶之庭》，在海内外获得较高评价。','','1','')
insert into Books values('万古江河','许倬云','2','9787556116904','350000','68','这本《万古江河（中国历史文化的转折与开展）》是心怀中国文化的著名史家许倬云先生交出的一份答卷，也是为今天中国人撰写的历史，为中国文化的成长发展作的一部传记。','许倬云，1930年生于江苏无锡，1962年获美国芝加哥大学博士学位，先后执教于台湾大学、美国匹兹堡大学，其间多次受聘为香港中文大学、美国夏威夷大学、美国杜克大学、香港科技大学讲座教授。','','2','')
insert into Books values('中国古代民族志','文史知识编辑部','4','7101009689','150000','13','我们的前人创造了无与伦比的灿烂文化，春秋战国的诸子哲学，韩柳欧苏的大块文章，明清之际人生画卷，无不表现了对社会国家的情情，对宇宙世界的期待。','文史知识编辑部','','2','')
insert into Books values('清华藏珍','暂无','5','9787302252146','60000','200','本书从清华大学图书馆和美术图书馆的收藏中，选取了100件文物珍品，分成文献、青铜器、书画、陶瓷、家具、织绣六个系列，配以插图和简要的说明文字，于清华大学百年校庆之际出版，作为清华大学百年文物收藏一个部分的记录，读者从中可以了解清华大学所藏文物的风貌。','暂无','','2','')
insert into Books values('正德十六年欧洲那些事儿','马瑞民','5','9787302552246','351000','58','本书内容以正德十六年（1521年）为中心，向前向后延伸到正德和嘉靖两位皇帝整个统治期，整个周期约六十年。 在此之前的欧洲各国，其经济、文化发达程度、综合国力尚不如大明帝国，远远不如。然而，就在这六十年里，欧洲通过大航海、文艺复兴和宗教改革，就像装上了三枚火箭推进器，加快了速度，超过了大明。 让我们在轻松中，在幽默中阅读欧洲这些人，那些事。','马瑞民，中国科学院研究生院MBA导师。北京市政府特邀建议人。发表过四部作品，《新编战略管理咨询实务》、《战略管理工具》、《品三国 说谋士》，《万历十五年欧洲那些事儿》。在国内的媒体发表过近百篇文章。','','2','')
insert into Books values('齐鲁经典文化与当代社会','张学成','5','9787302498520','441000','68','本书研究对象以先秦时期为主，兼顾其他时代，选择孔子、墨子、曾子、子思、管子、晏子、孟子、荀子、鬼谷子、孙武、诸葛亮、颜之推等十二位齐鲁诸子创造的经典思想文化作为研究对象。','张学成，男，1972年生，山东临沂人。临沂大学教授，文学博士，临沂大学学术委员会委员，中国史记研究会会员，中国李清照、辛弃疾研究会会员，山东孙子研究会理事。','','2','')
insert into Books values('寻找缺失的宇宙-暗物质','李金','5','9787302472322','200000','69','从20世纪40年代提出暗物质概念以来，宇宙观察中发现的很多引力现象都表明宇宙中隐藏了大量的暗物质，其质量约占宇宙物质总质量的85% 。','作者李金，中国科学院高能所研究员，清华大学客座教授。他可以告诉你暗物质的前世今生。他的故事中最精彩的篇章是关于一个世界上最深的地下暗物质探测实验室。','','3','')
insert into Books values('上帝如何设计世界-爱因斯坦的困惑','张天蓉','5','9787302396093','157000','35','科学研究探索的是万物之本。万物之本是什么？上帝是如何设计这个世界的？这是爱因斯坦的困惑。首先简单概括了牛顿力学及麦克斯韦电磁理论。从经典理论碰到的困难，引出爱因斯坦建立相对论的思考和历史过程。','张天蓉，女，科普作家，美国得州奥斯汀大学理论物理博士，现住美国芝加哥。研究课题包括广义相对论、黑洞辐射、费曼路径积分、毫微微秒激光、集成电路EDA软件等。','','3','')
insert into Books values('时间之问','汪波','5','9787302507598','404000','79','汪波著的《时间之问》是一部少有的打通学科边界，融合科技与人文内涵的通识之作。作品以大学师生的问答对谈开始，选取“时间”作为跨学科讨论的媒介，联结起数学、天文、信息技术、音乐、生物、物理等不同学科，一来一往的对话中隐含了作者精心设置的问题，辅以精心制作的插图和经过严谨考证的学术资料。','汪波，法国国立里昂应用科学院（INSA-Lyon）硕士，利摩日（Limoges）大学微电子博士，曾在里昂纳米国家实验室（INL）从事科研工作。回国后任教于北京大学深圳研究生院，从事集成电路和跨学科研究。法国深厚的人文底蕴让他对科学与人文的融合产生极大的兴趣，每周他和学生在餐厅对话，一起发现科学的奥妙，享受思考的乐趣。','','3','')
insert into Books values('无言的呼唤:动物的感知.思考和表达','(美)卡尔·沙芬纳','5','	9787302523185','386000','80','这部非虚构类作品，通过几种典型野生动物——狼、象和虎鲸等的精彩故事，展示了动物是如何感知、思考和表达的。这些动物对工具的使用、计划的制定、复杂信息的传递，让我们看到了动物极其智慧的一面，而动物之间的那些悲欢离合、喜怒哀乐的情感表达，无一不是人类情感的再现。','卡尔•沙芬纳曾获得麦克阿瑟奖、皮尤奖和古根海姆奖，他的作品曾获得猎户星图书奖、兰南文学奖、美国国家学院知识传播奖，以及约翰•巴勒斯自然写作奖、詹姆斯•彼尔德基金会图书奖、乔治•拉布基金会奖。','','3','')
insert into Books values('萤火虫在中国','付新华','2','9787556106332','76000','42','《萤火虫在中国》是中国萤火虫研究第一人付新华教授十三年来的研究结晶。一本独一无二的萤火虫读本，有故事，有情怀，有诗意，带你走进梦幻般的萤火虫世界。','付新华 与萤火虫“一见钟情”的诗意学者 青岛人，华中农业大学植物科技学院副教授。自2000年起，致力于萤火虫的考察与研究，是中国第一个萤火虫博士，发现并命名了雷氏萤、武汉萤、穹宇萤等多种萤火虫。','','3','')
insert into Books values('Python数据分析与可视化','魏伟一','5','9787302546665','341000','49','《Python数据分析与可视化（第2版）-微课视频版/大数据与人工智能技术丛书》从Python数据分析的基础知识人手，结合大量的数据分析示例，系统地介绍数据分析与可视化方法，带领读者逐步掌握Python数据分析的相关知识，提高解决实际问题的能力。','魏伟一 单位：西北师范大学计算机科学与工程学院 职务：数据科学与大数据系副系主任 ','','4','')
insert into Books values('C#从入门到精通','明日科技编著','5','9787302535850','1068000','79.8','《C#从入门到精通（第5版）》从初学者角度出发，通过通俗易懂的语言、丰富多彩的实例，详细介绍了使用C#进行WinForm应用程序开发应该掌握的各方面技术。','明日科技，程序设计类畅销图书作者，绝大多数品种在“全国计算机图书排行榜”同品种排行中名列前茅，累计销售百万册。作者编写的《ASP.NET从入门到精通》长期占据各网店排行榜的榜首位置','','4','')
insert into Books values('SQL Server数据库教程','赵明渊','5','9787302468561','710000','59.5','本书以功能强大的关系数据库SQL Server 2012作为平台，以学生成绩数据库为主线，全面系统地介绍了SQL Server 2012的管理操作和应用开发，将基础知识和实际应用有机结合起来。','赵明渊，男，重庆市（籍贯），汉族，电子科技大学计算机应用技术专业博士，中国农业银行四川省分行计算机高级工程师','','4','')
insert into Books values('Android应用开发教程','赵明渊','5','9787302483182','718000','79.5','本书基于Android Studio和Eclipse开发环境，介绍Android系统体系结构和应用开发环境，Android应用的创建、调试和发布，Activity、Fragment和Intent，Android基本控件、高级控件，Android事件处理，后台服务，数据存储，多媒体服务，定位服务，应用项目开发等内容。','赵明渊，男，重庆市（籍贯），汉族，电子科技大学计算机应用技术专业博士，中国农业银行四川省分行计算机高级工程师','','4','')
insert into Books values('ASP.NET程序设计(慕课版)','明日科技编著','7','9787115451859','644000','59.8','《ASP.NET程序设计（慕课版）》是一本ASP.NET程序开发互联网教材，买书送名师，明日科技资深讲师面对面授课。','明日科技，程序设计类畅销图书作者，绝大多数品种在“全国计算机图书排行榜”同品种排行中名列前茅，累计销售百万册。作者编写的《ASP.NET从入门到精通》长期占据各网店排行榜的榜首位置','','4','')
insert into Books values('白色橄榄树','玖月晞','6','9787550032071','324469','69.8','“阿瓒，我下辈子想当一只鸟儿。”“——那我就当一棵大树。”橄榄树的意象，散落的果实，叶子化成的鸟儿，守护的力量感。拉页的设计，呈现出的是书中的定情之景。沙漠的橄榄树林，异国的除夕之夜，阿瓒和冉冉，惊心动魄里最平凡的爱情。 在见过最深的黑暗，最凶的罪恶，最丑的恐怖之后，我依然庆幸，我见过光明，见过善良，见过最美的心灵。我依然感激，我亲眼见过那一片白色橄榄树林。','晋江文学网签约作者，电影《少年的你》是改编自小说《少年的你，如此美丽》，获得诸多影视大奖','','1','')
go


select * from UserRoles
select * from UserStates
select * from Users
select * from Categories
select * from Publishers
select * from Orders
select * from Books
select * from OrderBook

select * from ShowInfo
select * from ShopCart

