/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app;

import dal.Repository;
import dal.RepositoryFactory;
import hr.algebra.utils.JAXBUtils;
import hr.algebra.utils.MessageUtils;
import java.util.logging.Level;
import java.util.logging.Logger;
import models.Login;
import models.MovieArchive;

/**
 *
 * @author Mateo
 */
public class MainApp extends javax.swing.JFrame {

   public  Login login = null;
   private static String FILENAME = "moviearchive.xml";
   private Repository repo;
    /**
     * Creates new form MainApp
     */
    public MainApp() {
        initComponents();
        initRepo();
    }

    /**
     * This method is called from within the constructor to initialize the form. WARNING: Do NOT modify this code. The content of this method is always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        tpContent = new javax.swing.JTabbedPane();
        jMenuBar1 = new javax.swing.JMenuBar();
        jmXML = new javax.swing.JMenu();
        jmiDownload = new javax.swing.JMenuItem();
        jmApp = new javax.swing.JMenu();
        jmiExit = new javax.swing.JMenuItem();
        jmiLogOut = new javax.swing.JMenuItem();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("MovieViewer");
        setMinimumSize(new java.awt.Dimension(1050, 900));
        setPreferredSize(new java.awt.Dimension(1050, 900));

        jmXML.setText("XML");

        jmiDownload.setText("Download XML");
        jmiDownload.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jmiDownloadActionPerformed(evt);
            }
        });
        jmXML.add(jmiDownload);

        jMenuBar1.add(jmXML);

        jmApp.setText("App");

        jmiExit.setText("Exit");
        jmiExit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jmiExitActionPerformed(evt);
            }
        });
        jmApp.add(jmiExit);

        jmiLogOut.setText("Switch user");
        jmiLogOut.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jmiLogOutActionPerformed(evt);
            }
        });
        jmApp.add(jmiLogOut);

        jMenuBar1.add(jmApp);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(tpContent, javax.swing.GroupLayout.DEFAULT_SIZE, 1001, Short.MAX_VALUE)
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addComponent(tpContent, javax.swing.GroupLayout.PREFERRED_SIZE, 950, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(0, 0, Short.MAX_VALUE))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jmiDownloadActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jmiDownloadActionPerformed
       
       try {
           JAXBUtils.save(new MovieArchive(repo.getMovies()), FILENAME);
           MessageUtils.showInformationMessage("Info", "Movies saved");
       } catch (Exception ex) {
           MessageUtils.showErrorMessage("Error", "Unable to save movies");
           Logger.getLogger(MainApp.class.getName()).log(Level.SEVERE, null, ex);
       }
        
    }//GEN-LAST:event_jmiDownloadActionPerformed

    private void jmiExitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jmiExitActionPerformed
       
        if (MessageUtils.showConfirmDialog("Exit", "Are you sure you want to exit the application?") == 0){
             try {
                  
               System.exit(0);
                 
                 
             } catch (Exception ex) {
                  MessageUtils.showErrorMessage("", "Failed to exit");
             }
         }
        
        
    }//GEN-LAST:event_jmiExitActionPerformed

    private void jmiLogOutActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jmiLogOutActionPerformed
        
        
        if (MessageUtils.showConfirmDialog("", "Are you sure you want to switch user?") == 0){
             try {
                  
                 LoginForm lf = new LoginForm();
                 lf.setVisible(true);
                 this.dispose();
                 
                 
             } catch (Exception ex) {
                  MessageUtils.showErrorMessage("", "Failed to log out");
             }
         }
        
       
    }//GEN-LAST:event_jmiLogOutActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(MainApp.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(MainApp.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(MainApp.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(MainApp.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new MainApp().setVisible(true); 
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenu jmApp;
    private javax.swing.JMenu jmXML;
    private javax.swing.JMenuItem jmiDownload;
    private javax.swing.JMenuItem jmiExit;
    private javax.swing.JMenuItem jmiLogOut;
    private javax.swing.JTabbedPane tpContent;
    // End of variables declaration//GEN-END:variables

    public void displayContent() {
         if(login.isAdmin()){
        
       tpContent.add("Admin Panel",new AdminPanel());
        }
        else{
         tpContent.add("Movies", new MoviesPanel());
         tpContent.add("People", new PeoplePanel());
         tpContent.add("Genres", new GenresPanel());
        }
    }

    private void initRepo() {
        repo = RepositoryFactory.getRepository();
    }
}
