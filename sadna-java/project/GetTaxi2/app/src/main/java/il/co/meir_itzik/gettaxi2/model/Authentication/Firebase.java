package il.co.meir_itzik.gettaxi2.model.Authentication;

import android.support.annotation.NonNull;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;

import java.util.concurrent.Executor;


public class Firebase implements AuthService {
    private FirebaseAuth mAuth = FirebaseAuth.getInstance();

    public void registerUserWithEmailAndPassword(String email, String password, final RunAction<FirebaseUser> action) {
        mAuth.createUserWithEmailAndPassword(email, password)
                .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if (task.isSuccessful()) {
                            // Sign in success, update UI with the signed-in user's information
                            FirebaseUser user = mAuth.getCurrentUser();
                            action.onSuccess(user);
                        } else {
                            // If sign in fails, display a message to the user.
                            action.onFailure(null, task.getException().toString());
                        }

                        // ...
                    }
                });
    }

    public void signInUserWithEmailAndPassword(String email, String password, final RunAction<FirebaseUser> action) {
        mAuth.signInWithEmailAndPassword(email, password)
                .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if (task.isSuccessful()) {
                            // Sign in success, update UI with the signed-in user's information
                            FirebaseUser user = mAuth.getCurrentUser();
                            action.onSuccess(user);
                        } else {
                            // If sign in fails, display a message to the user.
                            action.onFailure(null, task.getException().toString());
                        }

                        // ...
                    }
                });
    }

    public void logout(){
        mAuth.signOut();
    }
}
