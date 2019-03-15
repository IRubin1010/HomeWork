package il.co.meir_itzik.gettaxi1.model.backend;

import android.os.AsyncTask;

public class RunDbActionAsync extends AsyncTask<Void,Void,Void> {

    public interface AsyncRunner {
        void onPreExecute();
        Void doInBackground();
        void onPostExecute();
    }

    AsyncRunner asyncRunner;

    public RunDbActionAsync(AsyncRunner asyncRunner){
        this.asyncRunner = asyncRunner;
    }

    @Override
    protected Void doInBackground(Void... voids) {
        return this.asyncRunner.doInBackground();
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        this.asyncRunner.onPreExecute();
    }

    @Override
    protected void onPostExecute(Void aVoid) {
        super.onPostExecute(aVoid);
        this.asyncRunner.onPostExecute();
    }
}
