import {useTranslation} from "react-i18next";
import {useEffect, useState} from "react";
import ReactCountryFlag from "react-country-flag"

export interface LanguagePickerProps {
}

function LanguagePicker(props: LanguagePickerProps) {
    const { i18n } = useTranslation();
    const [lngs, setLngs] = useState<any>({ en: { nativeName: 'English' }});
    useEffect(() => {
        i18n.services.backendConnector.backend.getLanguages((err: any, ret: any) => {
            if (err) return // TODO: handle err...
            setLngs(ret);
        });
    }, []);

    return <div style={{
        position: 'fixed',
        top: 0,
        right: 0,
        zIndex: 100,
        backgroundColor: 'white',
        padding: '10px',
        borderRadius: '5px',
        boxShadow: '0px 0px 5px #ccc',
    }}>
        <select defaultValue={i18n.language} onChange={(e) => i18n.changeLanguage(e.target.value)}>
            {Object.keys(lngs).map((lng: string) => (
                <option key={lng} value={lng}>
                    {lngs[lng].nativeName}
                </option>
            ))}
        </select>
    </div>
}

export default LanguagePicker;