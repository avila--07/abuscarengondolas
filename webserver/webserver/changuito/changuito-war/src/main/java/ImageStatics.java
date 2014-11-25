
import com.google.appengine.api.datastore.Blob;
import com.google.appengine.api.datastore.Key;

import javax.jdo.annotations.Extension;
import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

/**
 * JDO-annotated model class for storing movie properties; movie's promotional
 * image is stored as a Blob (large byte array) in the image field.
 */
@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class ImageStatics{

    @PrimaryKey
    @Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
    private Key key;

    @Persistent
    private String title;

    @Persistent
    @Extension(vendorName="datanucleus", key="gae.unindexed", value="true")
    private String imageType;

    @Persistent
    private Blob image;

    public Long getId() {
        return key.getId();
    }

    public String getTitle() {
        return title;
    }

    public String getImageType() {
        return imageType;
    }

    public byte[] getImage() {
        if (image == null) {
            return null;
        }

        return image.getBytes();
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public void setImageType(String imageType) {
        this.imageType = imageType;
    }

    public void setImage(byte[] bytes) {
        this.image = new Blob(bytes);
    }

}