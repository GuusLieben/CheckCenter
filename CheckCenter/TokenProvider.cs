namespace CheckCenter {
    public class TokenProvider {
        //public string AuthorizeUser(string UserEmail, string Password) {
            //Get user details for the user who is trying to login


            //Authenticate User, Check if it’s a registered user in Database 
            //if (user == null)
            //    return null;

            //If it is registered user, check user password stored in Database
            //For demo, password is not hashed. It is just a string comparision 
            //In reality, password would be hashed and stored in Database. 
            //Before comparing, hash the password again.
            //if (Password == user.PASSWORD)
            //{
                //Authentication successful, Issue Token with user credentials 
                //Provide the security key which is given in 
                //Startup.cs ConfigureServices() method 
        //        var key = Encoding.ASCII.GetBytes
        //        ("SecretKey-2374-BVADO75ADFV9:859372Y128-tyuw-0131-6573-hvasrg97ad98f");
        //        //Generate Token for user 
        //        var JWToken = new JwtSecurityToken(
        //            issuer: "http://localhost:5001/",
        //            audience: "http://localhost:5001/",
        //            claims: GetUserClaims(user),
        //            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
        //            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
        //            //Using HS256 Algorithm to encrypt Token  
        //            signingCredentials: new SigningCredentials
        //            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //        );
        //        var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
        //        return token;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //Using hard coded collection list as Data Store for demo. 
        //In reality, User data comes from Database or other Data Source 
        //private IEnumerable<Claim> GetUserClaims(User user)
        //{
        //    IEnumerable<Claim> claims = new Claim[] {
        //        new Claim("UserEmail", user.UserEmail),
        //        new Claim("FirstName", user.FirstName),
        //        new Claim("LastName", user.LastName),
        //    }; return claims;
        //}
    }
}