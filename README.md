
Final Project in Advanced C# course (JB)


סוג הפרויקט: WinForms Application, Class Libraries.
הדרישה: אפליקציית צ'אט בין מחשבים.
ידע נדרש: 
Delegates & Events
עבודה עם TCP בעזרת המחלקות: TcpClient, TcpListener
Serialization
Threading
עבודה עם טפסים

כיצד האפליקציה תעבוד?
במערכת תהיה אפליקציה אשר תותקן אצל משתמש המעוניין להשתתף בצ'אט ולשוחח עם משתמשים אחרים ברשת. לאפליקציה זו נקרא "צד הלקוח”. בעזרת אפליקציית הלקוח המשתמש יוכל לשלוח הודעות לשאר המשתתפים בצ'אט ולקבל מהם הודעות בחזרה.
 
כיצד אפליקציית צד הלקוח מתקשרת עם מחשבים אחרים ? (שולחת ומקבל הודעות)
אפליקציית צד הלקוח לא יכולה לדעת אילו משתמשים נוספים קיימים ברשת (מה כתובת ה- IP שלהם) אשר משתתפים בצ'אט. כאשר אנו רוצים לשלוח הודעה שתגיע לכל המשתתפים, במקום לשלוח את ההודעה לכל המשתתפים (אנחנו הרי לא יודעים מי בכל זמן נתון מחובר לצ'אט) יהיה נבון אם נצור "מוקד" הודעות, אליו נשלח את ההודעה והוא יפיץ את ההודעה שלנו לשאר המשתתפים. על המוקד כמובן לדעת בכל זמן נתון מי כרגע מחובר לצ'אט. כאן נכנסת אפליקציית "צד השרת".

כיצד תעבוד אפליקציית "צד השרת"?
יש לכתוב אפליקציה נוספת (צד השרת) שתהווה את מוקד ההודעות. כל משתתף בצ'אט יצטרך להתחבר לשרת ולתקשר מולו. כלומר, נשלח את ההודעות שלנו לשרת, אשר יפיץ אותן לכל שאר המשתתפים, ובחזרה נקבל ממנו את ההודעות שמשתתפים אחרים שלחו דרכו אלינו.

פונקציונאליות:
צד הלקוח
האפליקציה תאפשר למשתמש לבחור:
כתובת ה- IP ומספר ה- Port של המחשב המריץ את אפליקציית השרת.
שם משתמש (כינוי), בכדי שמשתמשים אחרים ידעו ממי הם קיבלו את ההודעה.
צבע הגופן, כך שהודעות ממשתתף מסוים יופיעו בצבע שהוא בחר – יש להשתמש ב-Color
האפליקציה תאפשר למשתמש להקליד הודעה ולשלוח אותה לשרת.
האפליקציה תציג את כל ההודעות שהשרת שולח למשתמש.
אפשרות להתנתק ולהתחבר שוב לצ'אט.

אתגר :
מערכת צד הלקוח תאפשר משלוח הודעות פרטיות בין משתמשים על ידי שימוש בשם הלקוח שאליו מיועדת ההודעה.


צד השרת
האפליקציה תאפשר למפעיל תוכנת השרת לבחור את כתובת ה- IP ומספר ה- Port של המחשב המריץ את אפליקציית השרת.
בצד השרת יהיה ניתן לראות את שמות כל המשתתפים בצ'אט בכל רגע נתון, בנוסף יהיה ניתן לצפות בהיסטוריה של פעילות ההתחברות וההתנתקות בצ'אט – לכל פריט בהיסטוריה יש לפרט: (1) מה הפעולה (התחברות או התנתקות) (2) מתי (3) מי.
