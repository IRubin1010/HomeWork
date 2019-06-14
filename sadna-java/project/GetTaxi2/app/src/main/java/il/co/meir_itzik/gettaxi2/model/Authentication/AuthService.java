package il.co.meir_itzik.gettaxi2.model.Authentication;

import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.firebase.auth.FirebaseUser;

public interface AuthService {

    public interface RunAction<T>{
        void onSuccess(T obj);
        void onFailure(T obj, String msg);
    }

    void registerUserWithEmailAndPassword(String email, String password, final RunAction<FirebaseUser> action);

    void signInUserWithEmailAndPassword(String email, String password, final RunAction<FirebaseUser> action);

    void logout();

    boolean isLoggedIn();

    void logInWithGoogle(GoogleSignInAccount account, final RunAction<FirebaseUser> action);

}
