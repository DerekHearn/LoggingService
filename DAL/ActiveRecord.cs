


#pragma warning disable 1591 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace LoggingService.DAL
{
    
    
    /// <summary>
    /// A class which represents the TextLog table in the Meetball Database.
    /// </summary>
    public partial class TextLog: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<TextLog> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<TextLog>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<TextLog> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(TextLog item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                TextLog item=new TextLog();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<TextLog> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public TextLog(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                TextLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TextLog>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public TextLog(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public TextLog(Expression<Func<TextLog, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<TextLog> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<TextLog> _repo;
            
            if(db.TestMode){
                TextLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TextLog>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<TextLog> GetRepo(){
            return GetRepo("","");
        }
        
        public static TextLog SingleOrDefault(Expression<Func<TextLog, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            TextLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static TextLog SingleOrDefault(Expression<Func<TextLog, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            TextLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<TextLog, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<TextLog, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<TextLog> Find(Expression<Func<TextLog, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<TextLog> Find(Expression<Func<TextLog, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<TextLog> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<TextLog> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<TextLog> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<TextLog> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<TextLog> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<TextLog> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "TextLogID";
        }

        public object KeyValue()
        {
            return this.TextLogID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ToPhone.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(TextLog)){
                TextLog compare=(TextLog)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.TextLogID;
        }
        
        public string DescriptorValue()
        {
                            return this.ToPhone.ToString();
                    }

        public string DescriptorColumn() {
            return "ToPhone";
        }
        public static string GetKeyColumn()
        {
            return "TextLogID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ToPhone";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _TextLogID;
        public int TextLogID
        {
            get { return _TextLogID; }
            set
            {
                if(_TextLogID!=value){
                    _TextLogID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TextLogID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _FromUserID;
        public int? FromUserID
        {
            get { return _FromUserID; }
            set
            {
                if(_FromUserID!=value){
                    _FromUserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FromUserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ToPhone;
        public string ToPhone
        {
            get { return _ToPhone; }
            set
            {
                if(_ToPhone!=value){
                    _ToPhone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ToPhone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TextMessage;
        public string TextMessage
        {
            get { return _TextMessage; }
            set
            {
                if(_TextMessage!=value){
                    _TextMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TextMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<TextLog, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the PushLog table in the Meetball Database.
    /// </summary>
    public partial class PushLog: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PushLog> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PushLog>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PushLog> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(PushLog item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PushLog item=new PushLog();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PushLog> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public PushLog(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PushLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PushLog>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PushLog(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PushLog(Expression<Func<PushLog, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PushLog> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<PushLog> _repo;
            
            if(db.TestMode){
                PushLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PushLog>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PushLog> GetRepo(){
            return GetRepo("","");
        }
        
        public static PushLog SingleOrDefault(Expression<Func<PushLog, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PushLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PushLog SingleOrDefault(Expression<Func<PushLog, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PushLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PushLog, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PushLog, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PushLog> Find(Expression<Func<PushLog, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PushLog> Find(Expression<Func<PushLog, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PushLog> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PushLog> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PushLog> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PushLog> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PushLog> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PushLog> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PushLogID";
        }

        public object KeyValue()
        {
            return this.PushLogID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.PushMessage.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PushLog)){
                PushLog compare=(PushLog)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.PushLogID;
        }
        
        public string DescriptorValue()
        {
                            return this.PushMessage.ToString();
                    }

        public string DescriptorColumn() {
            return "PushMessage";
        }
        public static string GetKeyColumn()
        {
            return "PushLogID";
        }        
        public static string GetDescriptorColumn()
        {
            return "PushMessage";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _PushLogID;
        public int PushLogID
        {
            get { return _PushLogID; }
            set
            {
                if(_PushLogID!=value){
                    _PushLogID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PushLogID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _FromUserID;
        public int? FromUserID
        {
            get { return _FromUserID; }
            set
            {
                if(_FromUserID!=value){
                    _FromUserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FromUserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ToUserID;
        public int? ToUserID
        {
            get { return _ToUserID; }
            set
            {
                if(_ToUserID!=value){
                    _ToUserID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ToUserID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PushMessage;
        public string PushMessage
        {
            get { return _PushMessage; }
            set
            {
                if(_PushMessage!=value){
                    _PushMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PushMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PushLog, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the EmailBody table in the Meetball Database.
    /// </summary>
    public partial class EmailBody: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<EmailBody> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<EmailBody>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<EmailBody> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(EmailBody item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                EmailBody item=new EmailBody();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<EmailBody> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public EmailBody(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                EmailBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<EmailBody>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public EmailBody(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public EmailBody(Expression<Func<EmailBody, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<EmailBody> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<EmailBody> _repo;
            
            if(db.TestMode){
                EmailBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<EmailBody>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<EmailBody> GetRepo(){
            return GetRepo("","");
        }
        
        public static EmailBody SingleOrDefault(Expression<Func<EmailBody, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            EmailBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static EmailBody SingleOrDefault(Expression<Func<EmailBody, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            EmailBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<EmailBody, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<EmailBody, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<EmailBody> Find(Expression<Func<EmailBody, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<EmailBody> Find(Expression<Func<EmailBody, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<EmailBody> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<EmailBody> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<EmailBody> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<EmailBody> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<EmailBody> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<EmailBody> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "EmailBodyID";
        }

        public object KeyValue()
        {
            return this.EmailBodyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(EmailBody)){
                EmailBody compare=(EmailBody)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.EmailBodyID;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "EmailBodyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _EmailBodyID;
        public int EmailBodyID
        {
            get { return _EmailBodyID; }
            set
            {
                if(_EmailBodyID!=value){
                    _EmailBodyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmailBodyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Version;
        public int? Version
        {
            get { return _Version; }
            set
            {
                if(_Version!=value){
                    _Version=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Version");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _StatusID;
        public int? StatusID
        {
            get { return _StatusID; }
            set
            {
                if(_StatusID!=value){
                    _StatusID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Subject;
        public string Subject
        {
            get { return _Subject; }
            set
            {
                if(_Subject!=value){
                    _Subject=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Subject");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Body;
        public string Body
        {
            get { return _Body; }
            set
            {
                if(_Body!=value){
                    _Body=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Body");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _SimpleBody;
        public string SimpleBody
        {
            get { return _SimpleBody; }
            set
            {
                if(_SimpleBody!=value){
                    _SimpleBody=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SimpleBody");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<EmailBody, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the TextBody table in the Meetball Database.
    /// </summary>
    public partial class TextBody: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<TextBody> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<TextBody>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<TextBody> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(TextBody item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                TextBody item=new TextBody();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<TextBody> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public TextBody(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                TextBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TextBody>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public TextBody(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public TextBody(Expression<Func<TextBody, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<TextBody> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<TextBody> _repo;
            
            if(db.TestMode){
                TextBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<TextBody>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<TextBody> GetRepo(){
            return GetRepo("","");
        }
        
        public static TextBody SingleOrDefault(Expression<Func<TextBody, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            TextBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static TextBody SingleOrDefault(Expression<Func<TextBody, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            TextBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<TextBody, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<TextBody, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<TextBody> Find(Expression<Func<TextBody, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<TextBody> Find(Expression<Func<TextBody, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<TextBody> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<TextBody> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<TextBody> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<TextBody> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<TextBody> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<TextBody> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "TextBodyID";
        }

        public object KeyValue()
        {
            return this.TextBodyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(TextBody)){
                TextBody compare=(TextBody)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.TextBodyID;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "TextBodyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _TextBodyID;
        public int TextBodyID
        {
            get { return _TextBodyID; }
            set
            {
                if(_TextBodyID!=value){
                    _TextBodyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TextBodyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Version;
        public int? Version
        {
            get { return _Version; }
            set
            {
                if(_Version!=value){
                    _Version=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Version");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _StatusID;
        public int? StatusID
        {
            get { return _StatusID; }
            set
            {
                if(_StatusID!=value){
                    _StatusID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Body;
        public string Body
        {
            get { return _Body; }
            set
            {
                if(_Body!=value){
                    _Body=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Body");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<TextBody, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the PushBody table in the Meetball Database.
    /// </summary>
    public partial class PushBody: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<PushBody> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<PushBody>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<PushBody> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(PushBody item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                PushBody item=new PushBody();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<PushBody> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public PushBody(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                PushBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PushBody>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public PushBody(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public PushBody(Expression<Func<PushBody, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<PushBody> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<PushBody> _repo;
            
            if(db.TestMode){
                PushBody.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<PushBody>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<PushBody> GetRepo(){
            return GetRepo("","");
        }
        
        public static PushBody SingleOrDefault(Expression<Func<PushBody, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            PushBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static PushBody SingleOrDefault(Expression<Func<PushBody, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            PushBody single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<PushBody, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<PushBody, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<PushBody> Find(Expression<Func<PushBody, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<PushBody> Find(Expression<Func<PushBody, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<PushBody> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<PushBody> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<PushBody> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<PushBody> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<PushBody> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<PushBody> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "PushBodyID";
        }

        public object KeyValue()
        {
            return this.PushBodyID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(PushBody)){
                PushBody compare=(PushBody)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.PushBodyID;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "PushBodyID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _PushBodyID;
        public int PushBodyID
        {
            get { return _PushBodyID; }
            set
            {
                if(_PushBodyID!=value){
                    _PushBodyID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PushBodyID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _Version;
        public int? Version
        {
            get { return _Version; }
            set
            {
                if(_Version!=value){
                    _Version=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Version");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _StatusID;
        public int? StatusID
        {
            get { return _StatusID; }
            set
            {
                if(_StatusID!=value){
                    _StatusID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StatusID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Body;
        public string Body
        {
            get { return _Body; }
            set
            {
                if(_Body!=value){
                    _Body=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Body");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CreateDate;
        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if(_CreateDate!=value){
                    _CreateDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CreateDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<PushBody, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the MethodLog table in the Meetball Database.
    /// </summary>
    public partial class MethodLog: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MethodLog> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MethodLog>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MethodLog> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(MethodLog item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MethodLog item=new MethodLog();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MethodLog> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public MethodLog(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MethodLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLog>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MethodLog(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public MethodLog(Expression<Func<MethodLog, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MethodLog> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<MethodLog> _repo;
            
            if(db.TestMode){
                MethodLog.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLog>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MethodLog> GetRepo(){
            return GetRepo("","");
        }
        
        public static MethodLog SingleOrDefault(Expression<Func<MethodLog, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MethodLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MethodLog SingleOrDefault(Expression<Func<MethodLog, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MethodLog single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MethodLog, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MethodLog, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MethodLog> Find(Expression<Func<MethodLog, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MethodLog> Find(Expression<Func<MethodLog, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MethodLog> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MethodLog> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MethodLog> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MethodLog> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MethodLog> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MethodLog> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MethodLogID";
        }

        public object KeyValue()
        {
            return this.MethodLogID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.Name.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MethodLog)){
                MethodLog compare=(MethodLog)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MethodLogID;
        }
        
        public string DescriptorValue()
        {
                            return this.Name.ToString();
                    }

        public string DescriptorColumn() {
            return "Name";
        }
        public static string GetKeyColumn()
        {
            return "MethodLogID";
        }        
        public static string GetDescriptorColumn()
        {
            return "Name";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MethodLogID;
        public int MethodLogID
        {
            get { return _MethodLogID; }
            set
            {
                if(_MethodLogID!=value){
                    _MethodLogID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MethodLogID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if(_Name!=value){
                    _Name=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Name");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Parameters;
        public string Parameters
        {
            get { return _Parameters; }
            set
            {
                if(_Parameters!=value){
                    _Parameters=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Parameters");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _CallDate;
        public DateTime? CallDate
        {
            get { return _CallDate; }
            set
            {
                if(_CallDate!=value){
                    _CallDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CallDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _Successful;
        public bool? Successful
        {
            get { return _Successful; }
            set
            {
                if(_Successful!=value){
                    _Successful=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Successful");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _SessionGuid;
        public Guid? SessionGuid
        {
            get { return _SessionGuid; }
            set
            {
                if(_SessionGuid!=value){
                    _SessionGuid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SessionGuid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _ExceptionGuid;
        public Guid? ExceptionGuid
        {
            get { return _ExceptionGuid; }
            set
            {
                if(_ExceptionGuid!=value){
                    _ExceptionGuid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionGuid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _MBExceptionGuid;
        public Guid? MBExceptionGuid
        {
            get { return _MBExceptionGuid; }
            set
            {
                if(_MBExceptionGuid!=value){
                    _MBExceptionGuid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MBExceptionGuid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double? _Duration;
        public double? Duration
        {
            get { return _Duration; }
            set
            {
                if(_Duration!=value){
                    _Duration=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Duration");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        bool? _TestBool;
        public bool? TestBool
        {
            get { return _TestBool; }
            set
            {
                if(_TestBool!=value){
                    _TestBool=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TestBool");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _API;
        public string API
        {
            get { return _API; }
            set
            {
                if(_API!=value){
                    _API=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="API");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RetVal;
        public string RetVal
        {
            get { return _RetVal; }
            set
            {
                if(_RetVal!=value){
                    _RetVal=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RetVal");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<MethodLog, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the MethodLogException table in the Meetball Database.
    /// </summary>
    public partial class MethodLogException: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MethodLogException> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MethodLogException>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MethodLogException> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(MethodLogException item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MethodLogException item=new MethodLogException();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MethodLogException> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public MethodLogException(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MethodLogException.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLogException>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MethodLogException(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public MethodLogException(Expression<Func<MethodLogException, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MethodLogException> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<MethodLogException> _repo;
            
            if(db.TestMode){
                MethodLogException.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLogException>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MethodLogException> GetRepo(){
            return GetRepo("","");
        }
        
        public static MethodLogException SingleOrDefault(Expression<Func<MethodLogException, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MethodLogException single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MethodLogException SingleOrDefault(Expression<Func<MethodLogException, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MethodLogException single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MethodLogException, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MethodLogException, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MethodLogException> Find(Expression<Func<MethodLogException, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MethodLogException> Find(Expression<Func<MethodLogException, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MethodLogException> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MethodLogException> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MethodLogException> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MethodLogException> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MethodLogException> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MethodLogException> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MethodLogExceptionId";
        }

        public object KeyValue()
        {
            return this.MethodLogExceptionId;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ExceptionCode.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MethodLogException)){
                MethodLogException compare=(MethodLogException)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MethodLogExceptionId;
        }
        
        public string DescriptorValue()
        {
                            return this.ExceptionCode.ToString();
                    }

        public string DescriptorColumn() {
            return "ExceptionCode";
        }
        public static string GetKeyColumn()
        {
            return "MethodLogExceptionId";
        }        
        public static string GetDescriptorColumn()
        {
            return "ExceptionCode";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MethodLogExceptionId;
        public int MethodLogExceptionId
        {
            get { return _MethodLogExceptionId; }
            set
            {
                if(_MethodLogExceptionId!=value){
                    _MethodLogExceptionId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MethodLogExceptionId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _ExceptionGuid;
        public Guid? ExceptionGuid
        {
            get { return _ExceptionGuid; }
            set
            {
                if(_ExceptionGuid!=value){
                    _ExceptionGuid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionGuid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExceptionCode;
        public string ExceptionCode
        {
            get { return _ExceptionCode; }
            set
            {
                if(_ExceptionCode!=value){
                    _ExceptionCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExceptionSource;
        public string ExceptionSource
        {
            get { return _ExceptionSource; }
            set
            {
                if(_ExceptionSource!=value){
                    _ExceptionSource=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionSource");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExceptionMessage;
        public string ExceptionMessage
        {
            get { return _ExceptionMessage; }
            set
            {
                if(_ExceptionMessage!=value){
                    _ExceptionMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExceptionStackTrace;
        public string ExceptionStackTrace
        {
            get { return _ExceptionStackTrace; }
            set
            {
                if(_ExceptionStackTrace!=value){
                    _ExceptionStackTrace=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionStackTrace");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ExceptionTargetSite;
        public string ExceptionTargetSite
        {
            get { return _ExceptionTargetSite; }
            set
            {
                if(_ExceptionTargetSite!=value){
                    _ExceptionTargetSite=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionTargetSite");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ExceptionDate;
        public DateTime? ExceptionDate
        {
            get { return _ExceptionDate; }
            set
            {
                if(_ExceptionDate!=value){
                    _ExceptionDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ExceptionDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<MethodLogException, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the MethodLogError table in the Meetball Database.
    /// </summary>
    public partial class MethodLogError: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<MethodLogError> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<MethodLogError>(new LoggingService.DAL.MeetballDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<MethodLogError> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(MethodLogError item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                MethodLogError item=new MethodLogError();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<MethodLogError> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        LoggingService.DAL.MeetballDB _db;
        public MethodLogError(string connectionString, string providerName) {

            _db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                MethodLogError.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLogError>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public MethodLogError(){
             _db=new LoggingService.DAL.MeetballDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public MethodLogError(Expression<Func<MethodLogError, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<MethodLogError> GetRepo(string connectionString, string providerName){
            LoggingService.DAL.MeetballDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new LoggingService.DAL.MeetballDB();
            }else{
                db=new LoggingService.DAL.MeetballDB(connectionString, providerName);
            }
            IRepository<MethodLogError> _repo;
            
            if(db.TestMode){
                MethodLogError.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<MethodLogError>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<MethodLogError> GetRepo(){
            return GetRepo("","");
        }
        
        public static MethodLogError SingleOrDefault(Expression<Func<MethodLogError, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            MethodLogError single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static MethodLogError SingleOrDefault(Expression<Func<MethodLogError, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            MethodLogError single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<MethodLogError, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<MethodLogError, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<MethodLogError> Find(Expression<Func<MethodLogError, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<MethodLogError> Find(Expression<Func<MethodLogError, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<MethodLogError> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<MethodLogError> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<MethodLogError> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<MethodLogError> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<MethodLogError> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<MethodLogError> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "MethodLogErrorId";
        }

        public object KeyValue()
        {
            return this.MethodLogErrorId;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.MBExceptionCode.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(MethodLogError)){
                MethodLogError compare=(MethodLogError)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.MethodLogErrorId;
        }
        
        public string DescriptorValue()
        {
                            return this.MBExceptionCode.ToString();
                    }

        public string DescriptorColumn() {
            return "MBExceptionCode";
        }
        public static string GetKeyColumn()
        {
            return "MethodLogErrorId";
        }        
        public static string GetDescriptorColumn()
        {
            return "MBExceptionCode";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _MethodLogErrorId;
        public int MethodLogErrorId
        {
            get { return _MethodLogErrorId; }
            set
            {
                if(_MethodLogErrorId!=value){
                    _MethodLogErrorId=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MethodLogErrorId");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        Guid? _MBExceptionGuid;
        public Guid? MBExceptionGuid
        {
            get { return _MBExceptionGuid; }
            set
            {
                if(_MBExceptionGuid!=value){
                    _MBExceptionGuid=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MBExceptionGuid");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _MBExceptionCode;
        public string MBExceptionCode
        {
            get { return _MBExceptionCode; }
            set
            {
                if(_MBExceptionCode!=value){
                    _MBExceptionCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="MBExceptionCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FriendlyMessage;
        public string FriendlyMessage
        {
            get { return _FriendlyMessage; }
            set
            {
                if(_FriendlyMessage!=value){
                    _FriendlyMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FriendlyMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _DeveloperMessage;
        public string DeveloperMessage
        {
            get { return _DeveloperMessage; }
            set
            {
                if(_DeveloperMessage!=value){
                    _DeveloperMessage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="DeveloperMessage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ErrorDate;
        public DateTime? ErrorDate
        {
            get { return _ErrorDate; }
            set
            {
                if(_ErrorDate!=value){
                    _ErrorDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ErrorDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<MethodLogError, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
#pragma warning restore 1591 