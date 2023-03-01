/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import dal.sql.SqlRepo;

/**
 *
 * @author Mateo
 */
public class RepositoryFactory {

    private RepositoryFactory() {
    }
    
     public static Repository getRepository()  {
        return new SqlRepo();
    }
    
}
