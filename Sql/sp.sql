    --Select Librarian  
    Create Procedure SelectLibrarian    
    as     
    Begin    
    Select * from Librarian;    
    End  
  GO
  
    --Insert and Update Librarian  
    Create Procedure InsertUpdateLibrarian    
    (    
    @Id integer,    
    @Name varchar(40),    
    @Age integer,    
    @Email varchar(50),    
    @Address nvarchar(150),    
    @Action varchar(10)    
    )    
    As    
    Begin    
    if @Action='Insert'    
        Begin    
        Insert into Librarian([Name],Age,Email,[Address]) values(@Name,@Age,@Email,@Address);    
        End    
    if @Action='Update'    
        Begin    
        Update Librarian set Name=@Name,Age=@Age,Email=@Email,Address=@Address where LibrarianID=@Id;    
        End      
    End  
GO      
    --Delete Librarian  
    Create Procedure DeleteLibrarian    
    (    
     @Id integer    
    )    
    as     
    Begin    
     Delete Librarian where LibrarianID=@Id;    
    End  
GO
