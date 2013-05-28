﻿
DROP TABLE zhloahr.CRM_ADVERTISING CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_ADVERTISING
	(
	ID           INTEGER NOT NULL,
	CONTENT      NVARCHAR2 (1000),
	DELIVERYDATE DATE,
	CHANNELID    INTEGER,
	FREE         FLOAT,
	STATE        INTEGER,
	EVALUATE     INTEGER,
	REMARK       NVARCHAR2 (1000),
	DELETED      INTEGER,
	NAME         NVARCHAR2 (500),
	COMPANY      INTEGER,
	WORKNAME     NVARCHAR2 (200),
	CREATETIME   DATE,
	MODIFYTIME   DATE,
	FILEDIDS     NVARCHAR2 (1000),
	CONSTRAINT PK_ADVERTISING PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CATEGORY CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CATEGORY
	(
	ID          INTEGER NOT NULL,
	NAME        NVARCHAR2 (150),
	DESCRIPTION NVARCHAR2 (150),
	DELETED     INTEGER,
	VALUE       NVARCHAR2 (50),
	CODE        NVARCHAR2 (50),
	CREATETIME  DATE,
	MODIFYTIME  DATE,
	CONSTRAINT PK_CATEGORY PRIMARY KEY (ID),
	CONSTRAINT FK_CATEGORY_CATEGORY FOREIGN KEY (ID) REFERENCES zhloahr.CRM_CATEGORY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CATEGORYITEM CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CATEGORYITEM
	(
	ID           INTEGER NOT NULL,
	CATEGORYID   INTEGER NOT NULL,
	PARENTITEMID INTEGER,
	NAME         NVARCHAR2 (150),
	DESCRIPTION  NVARCHAR2 (150),
	DELETED      INTEGER,
	ORDERINDEX   INTEGER,
	OTHERINFO    NVARCHAR2 (50),
	CONSTRAINT PK_CATEGORYITEM PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_COMPANYACTION CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_COMPANYACTION
	(
	ID         INTEGER NOT NULL,
	CONTENT    NVARCHAR2 (1000),
	ACTIONDATE DATE,
	FREE       FLOAT,
	STATE      INTEGER,
	EVALUATE   INTEGER,
	NAME       NVARCHAR2 (50),
	COMPANY    INTEGER,
	DELETED    INTEGER,
	REMARK     NVARCHAR2 (1000),
	CREATETIME DATE,
	MODIFYTIME DATE,
	FILEDIDS   NVARCHAR2 (1000),
	WORKNAME   INTEGER,
	CONSTRAINT PK_CRM_COMPANYACTION PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CONTRACT CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CONTRACT
	(
	ID                 INTEGER NOT NULL,
	CONTRACTNAME       NVARCHAR2 (50),
	STATE              INTEGER,
	FILEDIDS           VARCHAR2 (500),
	CUSTOMERNAME       NVARCHAR2 (50),
	CODE               VARCHAR2 (50),
	STARTDATE          DATE,
	ENDDATE            DATE,
	SIGNPERSON         INTEGER,
	CUSTOMERSIGNPERSON NVARCHAR2 (50),
	SIGNDATE           DATE,
	SIGNADDRESS        NVARCHAR2 (50),
	STOREPLACE         NVARCHAR2 (50),
	SUM                FLOAT,
	SETTLESTATE        INTEGER,
	CREATEPERSON       INTEGER,
	CREATEDATE         DATE,
	REMARK             NVARCHAR2 (1000),
	CONTENT            NVARCHAR2 (1000),
	DELETED            INTEGER,
	COMPANY            INTEGER,
	CUSTOMERID         INTEGER,
	CUSTOMER           INTEGER,
	CREATETIME         DATE,
	MODIFYTIME         DATE,
	CONSTRAINT PK_CONTRACT PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_COOPERATION CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_COOPERATION
	(
	ID          INTEGER NOT NULL,
	REMARK      NVARCHAR2 (1000),
	CREATEDATE  DATE,
	NAME        NVARCHAR2 (50),
	TELNO       NVARCHAR2 (500),
	EMAIL       NVARCHAR2 (50),
	CONTACTNAME NVARCHAR2 (50),
	ADDRESS     NVARCHAR2 (100),
	FAX         NVARCHAR2 (50),
	COMPANY     INTEGER,
	DELETED     INTEGER,
	CREATETIME  DATE,
	MODIFYTIME  DATE,
	CONSTRAINT PK_CRM_COOPERATION PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CORP_INFO CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CORP_INFO
	(
	ID         NUMBER NOT NULL,
	NAME       NVARCHAR2 (512) DEFAULT '',
	AREA       INTEGER,
	CORPTYPE   INTEGER,
	URL        NVARCHAR2 (512) DEFAULT '',
	LINKMAN    NVARCHAR2 (64) DEFAULT '',
	LINKMANTEL NVARCHAR2 (512) DEFAULT '',
	TELPHONE   NVARCHAR2 (512) DEFAULT '',
	FAX        NVARCHAR2 (512) DEFAULT '',
	ADDRESS    NVARCHAR2 (512) DEFAULT '',
	QQ         NVARCHAR2 (512),
	REMARK     NVARCHAR2 (1024) DEFAULT '',
	CREATETIME DATE DEFAULT sysdate NOT NULL,
	MODIFYTIME DATE DEFAULT sysdate NOT NULL,
	CUSTOMERID INTEGER,
	DELETED    INTEGER,
	CONSTRAINT PK_CRM_CORP_INFO PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);


COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.NAME IS '公司名称';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.AREA IS '区域名字';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.CORPTYPE IS '景区：PARK 酒店：HOTEL 组团旅行社：ZTTRVEL   地接旅行社：DJTRVEL';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.URL IS '网址';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.LINKMAN IS '联系人';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.LINKMANTEL IS '联系人电话';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.TELPHONE IS '公司电话';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.FAX IS '公司传真';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.ADDRESS IS '公司地址';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.QQ IS 'QQ号';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.REMARK IS '备注信息';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.CREATETIME IS '创建时间';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.MODIFYTIME IS '修改时间';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.CUSTOMERID IS '客户基本信息ID';
COMMENT ON COLUMN zhloahr.CRM_CORP_INFO.DELETED IS '删除标识';


DROP TABLE zhloahr.CRM_CRMDICTIONARY CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CRMDICTIONARY
	(
	ID         INTEGER NOT NULL,
	"KEY"      NVARCHAR2 (100),
	VALUE      NVARCHAR2 (2000),
	DELETED    INTEGER,
	DEPICT     NVARCHAR2 (100),
	CREATETIME DATE,
	MODIFYTIME DATE,
	PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CUSTOMER CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTOMER
	(
	ID                 INTEGER NOT NULL,
	CODE               NVARCHAR2 (64) DEFAULT '',
	NAME               NVARCHAR2 (512) DEFAULT '',
	CREATETIME         DATE DEFAULT sysdate,
	MODIFYTIME         DATE DEFAULT sysdate,
	BELONGPERSON       INTEGER,
	CAR                NVARCHAR2 (150),
	CAGEGORY           INTEGER,
	CREDITRATING       INTEGER,
	LASTSPENDDATE      DATE,
	TOTALSCORE         INTEGER,
	CONTACTUSERINFOIDS NVARCHAR2 (1000),
	AREA               INTEGER,
	SHORTNAME          NVARCHAR2 (500),
	MEMBERCARD         INTEGER,
	COMPANY            INTEGER,
	DELETED            INTEGER,
	ACCTYPE            INTEGER,
	CUSTOMERTYPE       INTEGER,
	LEVELSORT          INTEGER,
	RELATIONLEVEL      INTEGER,
	IMPORTANTLEVEL     INTEGER,
	CREATEPERSON       INTEGER,
	REMARK             NVARCHAR2 (1024),
	CUSTOMERSOURCE     INTEGER,
	CUSTOMERBUSINESS   INTEGER,
	CONSTRAINT PK_CRM_CUSTOMER PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);


COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.ID IS '主键';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CODE IS '客户编号(唯一)格式化10 Id';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.NAME IS '客户名';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CREATETIME IS '创建时间';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.MODIFYTIME IS '修改时间';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.BELONGPERSON IS '所属人';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CAR IS '汽车牌照';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CAGEGORY IS '客户类型 如VIP 普通客户';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CREDITRATING IS '信用等级';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.LASTSPENDDATE IS '最后一次消费时间';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.TOTALSCORE IS '总积分';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CONTACTUSERINFOIDS IS '联系人';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.AREA IS '区域';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.SHORTNAME IS '简称';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.MEMBERCARD IS '会员卡ID';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.COMPANY IS '所属公司';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.DELETED IS '删除标识';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.ACCTYPE IS '为了系统扩展 使用配置
配置中扩展名为 CORP,OTA 等 为企业用户和个人。
电商使用： 用户类型 MG:系统管理 CON:普通用户 CORP:企业用户 OTA:OTA用户，系统接口使用扩展信息如OTA 等。';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.LEVELSORT IS '认可程度';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.RELATIONLEVEL IS '关系';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.IMPORTANTLEVEL IS '重要程度';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER.CREATEPERSON IS '创建人';


DROP TABLE zhloahr.CRM_CUSTOMER_CONTACTINFO CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTOMER_CONTACTINFO
	(
	ID            INTEGER NOT NULL,
	CUSTOMERID    INTEGER,
	NAME          NVARCHAR2 (50),
	SEX           NVARCHAR2 (5),
	TELNUMBER     NVARCHAR2 (50),
	PHONENUMBER   NVARCHAR2 (50),
	DUTYNAME      NVARCHAR2 (50),
	BIRTHDAY      DATE DEFAULT SYSDATE,
	EMAIL         NVARCHAR2 (50),
	QQ            NVARCHAR2 (50),
	MSN           NVARCHAR2 (50),
	IDCARD        NVARCHAR2 (50),
	ADDRESS       NVARCHAR2 (50),
	NATIVEPLACE   NVARCHAR2 (50),
	FAVORITES     NVARCHAR2 (50),
	REMARK        NVARCHAR2 (50),
	ISMAIN        INTEGER,
	CREATE_TIME   DATE DEFAULT SYSDATE,
	MODIFIED_TIME DATE DEFAULT SYSDATE,
	DELETED       INTEGER,
	CREATETIME    DATE,
	MODIFYTIME    DATE,
	CONSTRAINT PK_CRM_CUSTOMER_CONTACTINFO PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);


COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.ID IS 'FID(PK)';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.CUSTOMERID IS '客户ID';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.NAME IS '姓名';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.SEX IS '性别 Sex';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.TELNUMBER IS '固定电话 TelNumber';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.PHONENUMBER IS '手机号';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.DUTYNAME IS '职务
DutyName';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.BIRTHDAY IS '出生年月日';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.EMAIL IS '邮编';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.QQ IS 'QQ号';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.MSN IS 'MSN';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.IDCARD IS '身份证号 IDCard';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.ADDRESS IS '住址';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.NATIVEPLACE IS '籍贯 NativePlace';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.FAVORITES IS '爱好';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.REMARK IS '其他说明';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_CONTACTINFO.ISMAIN IS '是否主联系人';


DROP TABLE zhloahr.CRM_CUSTOMER_INFO CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTOMER_INFO
	(
	ID            INTEGER NOT NULL,
	REAL_NAME     NVARCHAR2 (512) DEFAULT '',
	IDCARD        NVARCHAR2 (64) DEFAULT '',
	IDCARD_IMG    NVARCHAR2 (512),
	REAL_AUTH     INTEGER DEFAULT 0,
	ADDR          NVARCHAR2 (512),
	TEL           NVARCHAR2 (512),
	POST          NVARCHAR2 (512),
	EMAIL         NVARCHAR2 (64) DEFAULT '',
	EMAIL_AUTH    INTEGER DEFAULT 0,
	MOBILE        NVARCHAR2 (64) DEFAULT '',
	MOBILE_AUTH   INTEGER DEFAULT 0,
	SEX           NVARCHAR2 (5),
	BIRTHDAY      DATE DEFAULT sysdate,
	CREATE_TIME   DATE DEFAULT sysdate NOT NULL,
	MODIFIED_TIME DATE DEFAULT sysdate NOT NULL,
	DELETED       INTEGER NOT NULL,
	CUSTOMERID    INTEGER,
	COMPANY       INTEGER,
	CONSTRAINT PK_CRM_CUSTOMER_INFO PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);


COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.ID IS '主键';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.REAL_NAME IS '用户名';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.IDCARD IS '身份证号';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.IDCARD_IMG IS '身份证图片';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.REAL_AUTH IS '实名认证';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.ADDR IS '详细地址';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.TEL IS '固定电话';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.POST IS '邮编';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.EMAIL IS '邮件地址';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.EMAIL_AUTH IS '0：未认证 1:认证';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.MOBILE IS '手机';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.MOBILE_AUTH IS '0：未认证 1:认证';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.SEX IS '女：FEMALE  男：MALE';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.BIRTHDAY IS '生日';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.CREATE_TIME IS '创建时间';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.MODIFIED_TIME IS '修改时间';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.DELETED IS '删除标志 0:未删除 1:已删除';
COMMENT ON COLUMN zhloahr.CRM_CUSTOMER_INFO.CUSTOMERID IS '客户ID';


DROP TABLE zhloahr.CRM_CUSTOMERAGREEMENT CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTOMERAGREEMENT
	(
	ID            INTEGER NOT NULL,
	DELETED       INTEGER NOT NULL,
	CREATETIME    TIMESTAMP,
	MODIFYTIME    TIMESTAMP,
	CUSTOMER      INTEGER,
	AGREEMENTTYPE INTEGER,
	FILEIDS       NVARCHAR2 (1000),
	REMARK        NVARCHAR2 (1000),
	CREATEUSER    INTEGER,
	EXPIRE        TIMESTAMP,
	CONTENT       NVARCHAR2 (1000),
	SUBJECT       NVARCHAR2 (1000),
	PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CUSTOMERVISITRECORD CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTOMERVISITRECORD
	(
	ID             INTEGER NOT NULL,
	CUSTOMERID     INTEGER,
	BUSINESSPEOPLE INTEGER,
	VISITDATE      DATE,
	OTHERPERSON    NVARCHAR2 (100),
	CONTENT        NVARCHAR2 (1000),
	FILEIDS        NVARCHAR2 (1000),
	DELETED        INTEGER,
	COMPANY        INTEGER,
	CREATETIME     DATE,
	MODIFYTIME     DATE,
	CONSTRAINT PK_CUSTOMERVISITRECORD PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_CUSTORMERCONSUMRECORD CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_CUSTORMERCONSUMRECORD
	(
	ID                   INTEGER NOT NULL,
	CONSUMPTIONDATE      DATE,
	CUSTOMERID           INTEGER,
	SPENDTOTAL           FLOAT,
	DISCOUNTTYPE         INTEGER,
	AFTERDISCOUNTFREE    FLOAT,
	SCORE                INTEGER,
	SCORERULE            INTEGER,
	WRITEDATE            DATE,
	WRITEPERSONID        INTEGER,
	DELETED              INTEGER,
	RECEIVEMONEY         FLOAT,
	COMPANY              INTEGER,
	REMARK               NVARCHAR2 (1000),
	CONSUMERDETAILS      NVARCHAR2 (1000),
	CREATETIME           DATE,
	MODIFYTIME           DATE,
	CONSUMERBUSINESSTYPE INTEGER,
	FILEDIDS             NVARCHAR2 (500),
	BUSSINESSPERSON      INTEGER,
	CONSTRAINT PK_CUSTORMERCONSUMRECORD PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_DISCUSSCUSTOMERRECORD CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_DISCUSSCUSTOMERRECORD
	(
	ID                   INTEGER NOT NULL,
	CUSTOMERID           INTEGER,
	CONTENT              NVARCHAR2 (1000),
	DISCUSSDATE          DATE,
	BUSSINESSPERSONID    INTEGER,
	OTHERPERSONNAME      NVARCHAR2 (1000),
	STATE                INTEGER,
	OLDBUSSINESSPERSONID INTEGER,
	FILEIDS              NVARCHAR2 (1000),
	DELETED              INTEGER,
	COMPANY              INTEGER,
	CREATETIME           DATE,
	MODIFYTIME           DATE,
	CONSTRAINT PK_DISCUSSCUSTOMERRECORD PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_FILEATTACHEMENT CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_FILEATTACHEMENT
	(
	ID         INTEGER NOT NULL,
	FILENAME   NVARCHAR2 (500),
	FILESIZE   INTEGER DEFAULT ((0)) NOT NULL,
	EXTENSION  NCHAR (10) NOT NULL,
	FILEPATH   NVARCHAR2 (150) NOT NULL,
	DELETED    INTEGER,
	FILEGUIDID VARCHAR2 (50),
	CONSTRAINT PK_FILEATTACHEMENT PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_FINANCIAL CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_FINANCIAL
	(
	ID               INTEGER NOT NULL,
	DELETED          INTEGER,
	CUSTOMERID       INTEGER,
	CUSTOMERNAME     NVARCHAR2 (100),
	SUMPRICE         NUMBER (18,4),
	FINANCIALDATE    DATE,
	CHARGEPERSON     INTEGER,
	TREATRESULT      NVARCHAR2 (1000),
	REMARK           NVARCHAR2 (1000),
	CREATETIME       DATE,
	MODIFYTIME       DATE,
	STATE            INTEGER,
	FINANCIALTYPE    INTEGER NOT NULL,
	NAME             NVARCHAR2 (100),
	COOPERATION      INTEGER,
	COMPANY          INTEGER,
	FILEDIDS         NVARCHAR2 (500),
	FINANCIALPAYTYPE INTEGER
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_HOLIDAY CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_HOLIDAY
	(
	ID          INTEGER NOT NULL,
	HOLIDAYDATE DATE,
	DESCRIPT    NVARCHAR2 (1000),
	DELETED     INTEGER,
	NAME        NVARCHAR2 (50),
	COMPANY     INTEGER,
	DATENUM     INTEGER,
	ISSENDMSG   INTEGER,
	MODIFYTIME  DATE,
	CREATETIME  DATE,
	CONSTRAINT PK_HOLIDAY PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_MEMBERSHIPCARD CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_MEMBERSHIPCARD
	(
	ID          INTEGER NOT NULL,
	CARDCODE    NCHAR (20) NOT NULL,
	DESCRIPTION NVARCHAR2 (50),
	VALIDDATE   DATE,
	DELETED     INTEGER,
	CARDTYPE    INTEGER,
	COMPANY     INTEGER,
	MODIFYTIME  DATE,
	CREATETIME  DATE,
	CONSTRAINT PK_MEMBERSHIPCARD PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_MESSAGECONTENT CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_MESSAGECONTENT
	(
	ID          INTEGER NOT NULL,
	MSGCONTENT  NVARCHAR2 (1000),
	TONUMBER    NVARCHAR2 (1000),
	CREATETIME  DATE,
	MODIFYTIME  DATE,
	ISSEND      INTEGER,
	DELETED     INTEGER DEFAULT 0,
	SENDCOUNT   INTEGER DEFAULT 0,
	MESSAGEDATE DATE,
	TEMPLATE    INTEGER,
	CONSTRAINT CRM_MESSAGECONTENT_PK PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_OPRHIST CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_OPRHIST
	(
	ID          INTEGER NOT NULL,
	OPRUSERNAME NVARCHAR2 (50),
	OPRACTION   NVARCHAR2 (50),
	STAGEDESC   NVARCHAR2 (50),
	OPRCOMMENT  NVARCHAR2 (50),
	OPRDATETIME TIMESTAMP,
	OPRUSER     INTEGER,
	REQUESTID   INTEGER,
	REQUESTTYPE NVARCHAR2 (50),
	CONSTRAINT PK_OPRHIST PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_PERMISSION CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_PERMISSION
	(
	ID      INTEGER NOT NULL,
	NAME    NVARCHAR2 (50),
	DELETED INTEGER DEFAULT ((0)),
	CONSTRAINT PK_PERMISSION PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_PERMISSION_ROLE CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_PERMISSION_ROLE
	(
	PERMISSIONID INTEGER,
	ROLEID       INTEGER,
	ID           INTEGER NOT NULL,
	CONSTRAINT PK_PERMISSION_ROLE PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_PERMISSION_USERINFO CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_PERMISSION_USERINFO
	(
	PERMISSIONID INTEGER NOT NULL,
	USERID       INTEGER NOT NULL,
	ID           INTEGER NOT NULL,
	ISDELETED    INTEGER,
	CONSTRAINT PK_PERMISSION_USERINFO PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_SPENDSCORE CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_SPENDSCORE
	(
	ID          INTEGER NOT NULL,
	SCORETYPE   INTEGER,
	DELETED     INTEGER,
	DESCRIPTION NVARCHAR2 (1000),
	REMARK      NVARCHAR2 (1000),
	CONSTRAINT PK_SPENDSCORE PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_SUGGEST CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_SUGGEST
	(
	ID                INTEGER NOT NULL,
	CONTENT           NVARCHAR2 (1000),
	SOLVERESULTS      NVARCHAR2 (1000),
	SOLVETYPE         INTEGER,
	SUGGESTTYPE       INTEGER,
	SUGGESTDATE       DATE,
	SOLVEDATE         DATE,
	FILEIDS           NVARCHAR2 (1000),
	DELETED           INTEGER,
	SUGGESTCOMPLAINTS INTEGER,
	COMPANY           INTEGER,
	CUSTOMERID        INTEGER,
	CUSTOMERNAME      NVARCHAR2 (50),
	CREATETIME        DATE,
	MODIFYTIME        DATE,
	HANDLERPERSON     INTEGER,
	DEALPERSON        INTEGER,
	CONSTRAINT PK_SUGGEST PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_TASK CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_TASK
	(
	ID               INTEGER NOT NULL,
	CREATEUSER       INTEGER,
	ASSIGNUSER       INTEGER,
	TASKCONTENT      NVARCHAR2 (2000),
	TASKPROCESS      INTEGER,
	STARTDATE        TIMESTAMP,
	EXPECTATIONDATE  TIMESTAMP,
	ACTUALDATE       TIMESTAMP,
	REMARK           NVARCHAR2 (2000),
	EXECUTIONCONTENT NVARCHAR2 (2000),
	MODIFYTIME       TIMESTAMP,
	CREATETIME       TIMESTAMP,
	DELETED          INTEGER,
	SUBJECT          NVARCHAR2 (1000),
	PRIMARY KEY (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_TEMPLATE CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_TEMPLATE
	(
	ID           INTEGER NOT NULL,
	DELETED      INTEGER,
	CREATETIME   DATE,
	MODIFYTIME   DATE,
	MSGCONTENT   NVARCHAR2 (1000),
	CREATEPERSON INTEGER,
	MSGTYPE      INTEGER,
	TEMPLATENAME NVARCHAR2 (50),
	TEMPLATECODE NVARCHAR2 (50),
	COMPANY      INTEGER
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);



DROP TABLE zhloahr.CRM_USERINFO CASCADE CONSTRAINTS;

CREATE TABLE zhloahr.CRM_USERINFO
	(
	ID            INTEGER NOT NULL,
	NAME          NVARCHAR2 (50),
	SEX           INTEGER NOT NULL,
	MOBILE        NCHAR (20),
	ADDRESS       NVARCHAR2 (150),
	JOBID         INTEGER,
	ENTRYDATE     DATE,
	LEAVEDATE     DATE,
	STATE         INTEGER,
	DEPTID        INTEGER,
	LEADERID      INTEGER,
	DELETED       INTEGER,
	LOGINNAME     NVARCHAR2 (50),
	PWD           NVARCHAR2 (50),
	LASTLOGINDATE DATE,
	LOGINCOUNT    INTEGER DEFAULT ((0)),
	LASTLOGINIP   NCHAR (50),
	CONSTRAINT PK_USERINFO PRIMARY KEY (ID),
	CONSTRAINT FK_USERINFO_USERINFO FOREIGN KEY (ID) REFERENCES zhloahr.CRM_USERINFO (ID)
	)
	TABLESPACE OAHR
	LOGGING
	NOCACHE
	STORAGE (BUFFER_POOL DEFAULT);

